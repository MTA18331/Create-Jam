using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float moveSpeed;

    public Vector3 targetPlayerPos;
    public Vector3 playerPos;

    private float yaw = 0f;
    private float panSpeed;
    private Vector3 startPos;
    private void Start()
    {
        startPos = transform.position;
        targetPlayerPos = transform.position;
        panSpeed = GameObject.Find("Main Camera").transform.GetComponent<CameraControls>().getPanSpeed(); //This needs to set panspeed to the exact value it is set to on main camera
    }

    void Update () {
        float step = moveSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.W))
        {
            targetPlayerPos += step * transform.forward; 
        }
        if (Input.GetKey(KeyCode.A))
        {
            targetPlayerPos -= transform.right * step;
        }
        if (Input.GetKey(KeyCode.D))
        {
            targetPlayerPos +=  transform.right * step; 
        }
        if (Input.GetKey(KeyCode.S))
        {
            targetPlayerPos -= step * transform.forward ;
        }
        targetPlayerPos.y = 0;
        transform.position = Vector3.MoveTowards(transform.position, targetPlayerPos,1f);
        yaw += panSpeed * Input.GetAxis("Mouse X") * Time.deltaTime * 10;
        transform.eulerAngles = new Vector3(0, yaw, 0f);
    }
}
