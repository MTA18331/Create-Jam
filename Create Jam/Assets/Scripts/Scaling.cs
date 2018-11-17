using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaling : MonoBehaviour
{
    public Vector3 temp;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void newoffset()
    {

        if (InfectionCounter.currentInfection < 30)
        {
            temp.x = 1;
            temp.y = 2F;
            temp.z = 1F;
        }
        //we store scale of this transform in temporary variable

        if (InfectionCounter.currentInfection >= 70)
        {
            //We change the values for this saved variable (not actual transform scale)
            temp.x = 0;
            temp.y = 1.1F;
            temp.z = 0;
        }
        if (InfectionCounter.currentInfection >= 50 && InfectionCounter.currentInfection < 70)
        {
            //We change the values for this saved variable (not actual transform scale)
            temp.x = 0;
            temp.y = 1.4F;
            temp.z = 0;
        }
        if (InfectionCounter.currentInfection >= 30 && InfectionCounter.currentInfection < 50)
        {
            //We change the values for this saved variable (not actual transform scale)
            temp.x = 0;
            temp.y = 1.7F;
            temp.z = 0;
        }
        //We assign temp variable back to transform scale
        transform.localScale = temp;

    }
}
