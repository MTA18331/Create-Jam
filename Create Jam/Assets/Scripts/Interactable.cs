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
        if(gameObject.tag != "Interactable") //if gameobject is not interatable we don't do anything.
        {
            return;
        }
        rend.material.color = Color.red;
        InteractionManager.instance.interactionTarget = gameObject;
        InteractionManager.instance.setItem(item);
    }

    private void OnMouseExit()
    {
        if (gameObject.tag != "Interactable") //if gameobject is not interatable we don't do anything.
        {
            return;
        }
        rend.material.color = startColor;
        InteractionManager.instance.interactionTarget = null;
        InteractionManager.instance.setItem(null);
    }
}
