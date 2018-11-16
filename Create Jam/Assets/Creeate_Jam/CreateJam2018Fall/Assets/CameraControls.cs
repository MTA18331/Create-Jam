using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraControls : MonoBehaviour {

    public GameObject objToFollow;
    public GameObject pointOnObjToFollow;
    public Vector3 offset;

    public float panSpeed = 10f;
    public float verticalSpeed = 8f;

    private float pitch = 0f;
    private float yaw = 0f;
   
	void Update () {
        yaw += panSpeed * Input.GetAxis("Mouse X") * Time.deltaTime * 10;
        pitch -= verticalSpeed * Input.GetAxis("Mouse Y") * Time.deltaTime * 10;
        pointOnObjToFollow.transform.eulerAngles = new Vector3(pitch, yaw, 0f);
        transform.rotation = pointOnObjToFollow.transform.rotation;

        transform.position = pointOnObjToFollow.transform.position + offset;
        objToFollow.transform.rotation = transform.rotation;
	}
    public float getPanSpeed()
    {
        return panSpeed;
    }
}
