using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public InventoryItem[] items;


    public void AddInventoryItem(InventoryItem addable)
    {
        //First check if the inventory is completely empty
        if (items == null)
        {
            items = new InventoryItem[1];
            items[0] = addable;
            return; //we are done;
        }

        //Then check if we have that specific type of item
        foreach(InventoryItem item in items)
        {
            if (item.index == addable.index)
            {
                item.Quantity += addable.Quantity;
                return;
            }
        }

        //Finally, if the inventory isn't empty but doesn't have the addable item, we expand it
        InventoryItem[] newItems = new InventoryItem[items.Length + 1];
        for (int i = 0; i < items.Length; i++)
            newItems[i] = items[i]; //copy them to new array; 

        newItems[items.Length] = addable;

        items = newItems;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
