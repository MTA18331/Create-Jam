﻿using System.Collections;
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
    public GameObject baby1;
    public GameObject baby2;
    public GameObject baby3;
    public GameObject baby4;
    public GameObject baby5;
    public GameObject baby6;
    public GameObject baby7;
    public GameObject baby8;
    public GameObject baby9;
    public GameObject baby10;
    public GameObject quitcanvas;
    public GameObject ui;
    public float infectionStart = 0;
    public static float currentInfection;
    public static float previouInfection;
    public float infectionLevel;
    float infection = 0.01F;

    bool dead = false;
    public GameObject PlayerCam;
        
	// Use this for initialization
	void Start () {
        
        currentInfection = infectionStart;
        infectionLevel = infectionStart;
        previouInfection = infectionStart;
	}
	


	// Update is called once per frame
	void Update () {
        if ((player.transform.position - this.transform.position).sqrMagnitude < 5 * 5)
        {
            previouInfection = currentInfection;
            currentInfection += 0.005F;
            infectionLevel += 0.005F;
        }
        if(baby1 != null)
        {
        if ((player.transform.position-baby1.transform.position).sqrMagnitude<5*5)
        {
            previouInfection = currentInfection;
            currentInfection += infection;
            infectionLevel += infection;
        }
        }
        if(baby2 != null)
        {
        if ((player.transform.position - baby2.transform.position).sqrMagnitude < 5 * 5)
        {
            previouInfection = currentInfection;
            currentInfection += infection;
            infectionLevel += infection;
        }
        }
        if(baby3 != null)
        {
        if ((player.transform.position - baby3.transform.position).sqrMagnitude < 5 * 5)
        {
            previouInfection = currentInfection;
            currentInfection += infection;
            infectionLevel += infection;
        }
        }
        if(baby4 != null)
        {
        if ((player.transform.position - baby4.transform.position).sqrMagnitude < 5 * 5)
        {
            previouInfection = currentInfection;
            currentInfection += infection;
            infectionLevel += infection;
        }
        }
        if(baby6 != null)
        {
        if ((player.transform.position - baby6.transform.position).sqrMagnitude < 5 * 5)
        {
            previouInfection = currentInfection;
            currentInfection += infection;
            infectionLevel += infection;
        }
        }
        if(baby7 != null)
        {
        if ((player.transform.position - baby7.transform.position).sqrMagnitude < 5 * 5)
        {
            previouInfection = currentInfection;
            currentInfection += infection;
            infectionLevel += infection;
        }
        }
        if (baby8 != null)
        {
        if ((player.transform.position - baby8.transform.position).sqrMagnitude < 5 * 5)
        {
            previouInfection = currentInfection;
            currentInfection += infection;
            infectionLevel += infection;
        }
        }
        if (baby9 != null)
        {

        if ((player.transform.position - baby9.transform.position).sqrMagnitude < 5 * 5)
        {
            previouInfection = currentInfection;
            currentInfection += infection;
            infectionLevel += infection;
        }
        }
        if(baby10 != null)
        {
        if ((player.transform.position - baby10.transform.position).sqrMagnitude < 5 * 5)
        {
            previouInfection = currentInfection;
            currentInfection += infection;
            infectionLevel += infection;
        }
        }
        if(baby5 != null) {
        if ((player.transform.position - baby5.transform.position).sqrMagnitude < 5 * 5)
        {
            previouInfection = currentInfection;
            currentInfection += infection;
            infectionLevel += infection;
        }
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
            //Destroy(gameObject);
            // play game over
            //GameOver.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            //ui.SetActive(false);
            //PlayerCam.GetComponent<CameraControlsV2>().enabled = false;
            quitcanvas.SetActive(true);
            print("hello");
        }
        else
        {
            print("you are already dead");
        }

    }
}
