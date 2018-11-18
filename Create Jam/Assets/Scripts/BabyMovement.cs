using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BabyMovement : MonoBehaviour
{


    
    int atTarget = 1;
    public float AggroDistance = 2f;
    private float timer = 0;

    private float timerMax = 0;
    public GameObject point1;
    public GameObject point2;

    public GameObject point3;

    
    public GameObject point4;
    public GameObject MainCamera;
    public float speed = 0.02f;
    


    void Start()
    {


    }


    void FixedUpdate()
    {
        if (atTarget == 0)
        {
            move(MainCamera);
        }
        if (atTarget == 1)
        {
            move(point2);
        }
        else if (atTarget == 2)
        {
            move(point3);
        }
        else if (atTarget == 3)
        {
            move(point4);
        }
        else if (atTarget == 4)
        {
            move(point1);
        }
    }

    void move(GameObject goal)
    {
        
        if (atTarget == 0)
        {
           // if (!Wait(0.1f)) return;
           // timer = 0;
            //Debug.Log("hej");
        }
        if (this.transform.position.x + AggroDistance >= MainCamera.transform.position.x & this.transform.position.x - AggroDistance <= MainCamera.transform.position.x & this.transform.position.z + AggroDistance >= MainCamera.transform.position.z & this.transform.position.z - AggroDistance <= MainCamera.transform.position.z)
        {
            goal = MainCamera;
            atTarget = 0;


        }
        else if (this.transform.position.x + 0.2 >= goal.transform.position.x & this.transform.position.x - 0.2 <= goal.transform.position.x & this.transform.position.z + 0.2 >= goal.transform.position.z & this.transform.position.z - 0.2 <= goal.transform.position.z)
        {

            if (atTarget == 4)
            {

                atTarget = 1;
            }
            else
            {
                atTarget++;
            }


        }
        else
        {
            float step = speed * Time.deltaTime + 0.1f;

            Vector3 ost = new Vector3 ((goal.transform.position.x), (this.transform.position.y), (goal.transform.position.z));
            transform.position = Vector3.MoveTowards(this.transform.position, ost, step);

        }
    }

    bool Wait(float seconds)
    {
        timerMax = seconds;

        timer += Time.deltaTime;

        if (timer >= timerMax)
        {
            return true; //max reached - waited x - seconds
        }

        return false;
    }
}
