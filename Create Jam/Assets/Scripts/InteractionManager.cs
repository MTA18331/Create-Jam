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
    public Item item;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))//left click
        {
            pickUpItem();
        }
        useItems();
    }

    public void setItem(Item targetItem)
    {
        item = targetItem;
    }
    void pickUpItem()
    {
        if(interactionTarget == null || Vector3.Distance(player.position,interactionTarget.transform.position) > interactionRange) // we don't do anything if there is no target or if target is out of range
        {
            return;
        }
        if(InventoryManager.instance.findOpenSlot() >= 0)
        {
            Debug.Log("Slot: " + InventoryManager.instance.findOpenSlot());
            InventoryManager.instance.inventory[InventoryManager.instance.findOpenSlot()] = item;
            Destroy(interactionTarget.gameObject);
        }
        else
        {
            //do something to tell play that inventory is full
            Debug.Log("Invetory is full!");
        }
    }

    void useItems()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("1 was pressed!");
            if(InventoryManager.instance.inventory[0] != null) 
            {
                //use item
                //change UI
                InventoryManager.instance.inventory[0] = null;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("2 was pressed!");
            if (InventoryManager.instance.inventory[1] != null)
            {
                //use item
                //change UI
                InventoryManager.instance.inventory[1] = null;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("3 was pressed!");
            if (InventoryManager.instance.inventory[2] != null)
            {
                //use item
                //change UI
                InventoryManager.instance.inventory[2] = null;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Debug.Log("4 was pressed!");
            if (InventoryManager.instance.inventory[3] != null)
            {
                //use item
                //change UI
                InventoryManager.instance.inventory[3] = null;
            }
        }
    }

}
