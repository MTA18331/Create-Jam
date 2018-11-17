using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BabyMovement : MonoBehaviour
{
    //public GameObject player;
   
  
    public GameObject point1;
    int atTarget = 1;
  
    public float speed = 10f;
    public GameObject point2;
  
    public GameObject point3;
  

    public GameObject point4;

    // Use this for initialization
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (atTarget==1)
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
            
            if (this.transform.position.x +0.2>= goal.transform.position.x & this.transform.position.x - 0.2 <= goal.transform.position.x & this.transform.position.z+0.2>= goal.transform.position.z & this.transform.position.z - 0.2 <= goal.transform.position.z)
            {
            Debug.Log(atTarget);
            // The step size is equal to speed times frame time.
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
            float step = speed * Time.deltaTime + 0.3f;

                
                transform.position = Vector3.MoveTowards(this.transform.position, goal.transform.position, step);
           
            }
        }

            
    }

