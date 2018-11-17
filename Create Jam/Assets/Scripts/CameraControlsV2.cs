using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControlsV2 : MonoBehaviour {

    public Transform playerBody;
    public Vector3 offset;
    public float mouseSensitivity;
    public float smoothFollow = 0.2f;
    public Vector3 temp;
    float xAxisClamp = 0.0f;
	void Awake () {
        Cursor.lockState = CursorLockMode.Locked;
	}

    private void Start()
    {
        temp = offset;
    }

    // Update is called once per frame
    void Update () {
        rotateCamera();
        moveCamera();
        newoffset();
    }

    void rotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        float xRotation = mouseX * mouseSensitivity;
        float yRotation = mouseY * mouseSensitivity;

        xAxisClamp -= yRotation;

        Vector3 targetRotCam = transform.rotation.eulerAngles;
        Vector3 targetRotBody = playerBody.rotation.eulerAngles;

        targetRotCam.x -= yRotation;
        targetRotCam.y += xRotation;
        targetRotBody.y += xRotation;
        targetRotCam.z =0f;

        //some clamp may be needed here...

        transform.rotation = Quaternion.Euler(targetRotCam);
        playerBody.transform.rotation = Quaternion.Euler(targetRotBody);
    }
    void newoffset()
    {
        if (InfectionCounter.currentInfection > InfectionCounter.previouInfection)
        {
            temp.y -= 0.0001F;

            InfectionCounter.previouInfection = InfectionCounter.currentInfection;
        }
     
        //We assign temp variable back to transform scale
        transform.localScale = temp;
        offset = new Vector3(0, temp.y, 0);
    }
    void moveCamera()
    {
        
        Vector3 targetCamPos = playerBody.position + offset;
        transform.position = Vector3.Slerp(transform.position, targetCamPos, smoothFollow);
    }
}
