using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControlsV2 : MonoBehaviour {

    public Transform playerBody;
    public Vector3 offset;
    public float mouseSensitivity;
    public float smoothFollow = 0.2f;

    float xAxisClamp = 0.0f;
	void Awake () {
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
        if (InfectionCounter.currentInfection <= 99)
        {
            rotateCamera();
            moveCamera();
        }
        else 
        {
            print("you are dead");


        }



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
    void moveCamera()
    {
        Vector3 targetCamPos = playerBody.position + offset;
        transform.position = Vector3.Slerp(transform.position, targetCamPos, smoothFollow);
    }
}
