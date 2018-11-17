using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectionCounter : MonoBehaviour {
    #region Singelton
    public static InfectionCounter instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public GameObject player;
    public GameObject cube;

    public float infectionStart = 0;
    public static float currentInfection;
    public static float previouInfection;
    public float infectionLevel;
    float infection = 0.01F;

    bool dead = false;

        
	// Use this for initialization
	void Start () {
        
        currentInfection = infectionStart;
        infectionLevel = infectionStart;
        previouInfection = infectionStart;
	}
	


	// Update is called once per frame
	void Update () {
        if ((player.transform.position-cube.transform.position).sqrMagnitude<5*5)
        {
            previouInfection = currentInfection;
            currentInfection += infection;
            infectionLevel += infection;
        }
        if (infectionLevel >= 100)
        {
            
            infection = 0;
            infectionLevel = 100;
            death();
           
        }



	}

    void death()
    {
        dead = true;
        if (player != null)
        {
            Destroy(gameObject);
            print("hello");
        }
        else
        {
            print("you are already dead");
        }

    }
}
