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

    public GameObject throwable;
    public bool targetEnemies = false;
    public GameObject enemyTarget;
    public float bulletSpeed =0.7f;

    private Item useItem;
    private bool itemThown = false;
    private GameObject objToAttWith;
    private int slot;
    private GameObject tempEnemyTarget;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))//left click
        {
            pickUpItem();
        }
        useItems();
        if(Input.GetKeyDown(KeyCode.Mouse0) && enemyTarget != null)
        {
            tempEnemyTarget = enemyTarget;
            throwObject(tempEnemyTarget.transform, player, objToAttWith, slot);
            itemThown = true;
            targetEnemies = false;
        }
        if(throwable != null && tempEnemyTarget.gameObject != null)
        {
            StartCoroutine(moveThrowable(throwable, tempEnemyTarget.transform));
        }
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
            //Debug.Log("Slot: " + InventoryManager.instance.findOpenSlot());
            InventoryManager.instance.inventory[InventoryManager.instance.findOpenSlot()] = item;
            Destroy(interactionTarget.gameObject);
        }
        else
        {
            //do something to tell play that inventory is full
            Debug.Log("Invetory is full!");
        }
    } //getting item into inventory

    void useItems()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(InventoryManager.instance.inventory[0] != null) 
            {
                useItem = InventoryManager.instance.inventory[0];
                if (useItem.getItemType().Equals("Damage"))
                {
                    attackEnemy(useItem.prefab,1);
                }
                if (useItem.getItemType().Equals("Heal"))
                {
                    heal();
                }
                //change UI
                //InventoryManager.instance.inventory[0] = null;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (InventoryManager.instance.inventory[1] != null)
            {
                useItem = InventoryManager.instance.inventory[1];
                if (useItem.getItemType().Equals("Damage"))
                {
                    attackEnemy(useItem.prefab,2);
                }
                if (useItem.getItemType().Equals("Heal"))
                {
                    heal();
                }
                //change UI
                //InventoryManager.instance.inventory[1] = null;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (InventoryManager.instance.inventory[2] != null)
            {
                useItem = InventoryManager.instance.inventory[2];
                if (useItem.getItemType().Equals("Damage"))
                {
                    attackEnemy(useItem.prefab,3);
                }
                if (useItem.getItemType().Equals("Heal"))
                {
                    heal();
                }
                //change UI
                //InventoryManager.instance.inventory[2] = null;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (InventoryManager.instance.inventory[3] != null)
            {
                useItem = InventoryManager.instance.inventory[3];
                if (useItem.getItemType().Equals("Damage"))
                {
                    attackEnemy(useItem.prefab,4);
                }
                if (useItem.getItemType().Equals("Heal"))
                {
                    heal();
                }
                //change UI
                //InventoryManager.instance.inventory[3] = null;
            }
        }
    }

    void attackEnemy(GameObject prefab, int inventorySlot)
    {
        Debug.Log("Attacking enemy");
        targetEnemies = true;
        setObjectToAttackWith(prefab);
        setInventorySlot(inventorySlot);
    }

    void heal()
    {
        Debug.Log("Reducing insanity");
    }

    void throwObject(Transform target, Transform origin, GameObject itemToTrow, int inventorySlot)
    {
        throwable = GameObject.Instantiate(itemToTrow, origin.position, origin.rotation);
        //do something to throw item at target
        //StartCoroutine(moveThrowable(Throwable, target));

        //removing item from inventory
        InventoryManager.instance.inventory[inventorySlot - 1] = null;
        Debug.Log("Setting slot " + (inventorySlot - 1) + " to null");
    } //removing inventory item here

    void setObjectToAttackWith(GameObject obj)
    {
        objToAttWith = obj;
    }

    void setInventorySlot(int inventorySlot)
    {
        slot = inventorySlot;
    }
    public void setEnemyTarget(GameObject Enemy)
    {
        enemyTarget = Enemy;
    }

    IEnumerator moveThrowable(GameObject objToMove, Transform target)
    {
        objToMove.transform.position = Vector3.Slerp(objToMove.transform.position, target.position, bulletSpeed * Time.deltaTime);
        if((objToMove.transform.position - target.position).magnitude < 0.5f)
        {
            //play bullet destroy animation
            Destroy(objToMove);
            //play enemy destroy animation
            Destroy(target.gameObject);
        }
        yield return new WaitForSeconds(0f);    
    }
}
