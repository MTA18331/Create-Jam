using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour {

    #region Singelton
    public static InteractionManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public float interactionRange = 2.0f;
    public Transform player;

    [HideInInspector]
    public GameObject interactionTarget;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))//left click
        {
            pickUpItem();
        }
    }

    void pickUpItem()
    {
        if(interactionTarget == null || Vector3.Distance(player.position,interactionTarget.transform.position) > interactionRange) // we don't do anything if there is no target or if target is out of range
        {
            return;
        }
        //do something with item
        Destroy(interactionTarget.gameObject);
    }

}
