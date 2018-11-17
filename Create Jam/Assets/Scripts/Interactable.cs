using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {
    #region setRender
    public Renderer rend;
	void Awake () {
        rend = GetComponent<Renderer>();
	}
    #endregion

    public Item item;

    private Color startColor;

    private void Start()
    {
        startColor = rend.material.color;
    }
    // Update is called once per frame
    void Update () {
		
	}

    private void OnMouseEnter()
    {
        if(gameObject.tag == "Interactable" && InteractionManager.instance.targetEnemies == false) //if gameobject is not interatable we don't do anything.
        {
            rend.material.color = Color.green;
            InteractionManager.instance.interactionTarget = gameObject;
            InteractionManager.instance.setItem(item);
        }
        if(gameObject.tag == "Enemy" && InteractionManager.instance.targetEnemies == true && InteractionManager.instance.throwable == null)
        {
            rend.material.color = Color.red;
            InteractionManager.instance.setEnemyTarget(gameObject);
        }
    }


    private void OnMouseExit()
    {
        if (gameObject.tag == "Interactable") //if gameobject is not interatable we don't do anything.
        {
            rend.material.color = startColor;
            InteractionManager.instance.interactionTarget = null;
            InteractionManager.instance.setItem(null);
        }
        
        if (gameObject.tag == "Enemy")
        {
            rend.material.color = startColor;
            InteractionManager.instance.setEnemyTarget(null);
        }
    }
}
