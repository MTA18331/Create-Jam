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
    public GameObject baby1;
    public GameObject baby2;
    public GameObject quitcanvas;
    public GameObject ui;
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
        if ((player.transform.position - this.transform.position).sqrMagnitude < 5 * 5)
        {
            previouInfection = currentInfection;
            currentInfection += 0.001F;
            infectionLevel += 0.001F;
        }
        if ((player.transform.position-baby1.transform.position).sqrMagnitude<5*5)
        {
            previouInfection = currentInfection;
            currentInfection += infection;
            infectionLevel += infection;
        }
        if ((player.transform.position - baby2.transform.position).sqrMagnitude < 5 * 5)
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
            Cursor.lockState = CursorLockMode.None;
           // ui.SetActive(false);
            quitcanvas.SetActive(true);
            print("hello");
        }
        else
        {
            print("you are already dead");
        }

    }
}
