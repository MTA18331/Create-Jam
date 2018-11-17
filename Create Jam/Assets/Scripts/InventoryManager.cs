using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {

    #region Singelton
    public static InventoryManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public int itemCarryLimit = 4;
    public Item[] inventory;

    private void Start()
    {
        inventory = new Item[itemCarryLimit];
    }

    public int findOpenSlot()
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if(inventory[i] == null)
            {
                return i;
            }
        }
        return -1;
    }

}
