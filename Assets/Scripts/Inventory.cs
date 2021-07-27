using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour
{
    public List<InventoryItem> items;
    public int Money = 0;

    private GameInfoHolder gih;

    public int CalculateLoad()
    {
        //This function sums together all InventoryItem quantities and returns it.

        int load = 0;
        foreach (InventoryItem item in items)
            load += item.Quantity;

        return load;
    }
    public bool IsFull()
    {
        //Returns if there is no more space left in the inventory
        int bpLevel = transform.GetComponent<Robot>().backpackLevel;
        int bpCapacity = gih.BackpackCapacity[bpLevel];
        int load = CalculateLoad();
        return (bpCapacity <= load);

    }

    public void AddInventoryItem(InventoryItem addable)
    {
        //We check if we have that specific type of item
        foreach(InventoryItem item in items)
        {
            if (item.index == addable.index)
            {
                item.Quantity += addable.Quantity;
                return;
            }
        }

        //And if the inventory doesn't have the addable item, we expand it
        items.Add(addable);
    }

    public void SellItem(int index, int quantity = 1) //-1 for selling all
    {
        //We get the price of a singular item
        int oneprice = gih.OrePrice[items[index].index];

        if (quantity == -1)
            quantity = items[index].Quantity;
        else quantity = Mathf.Min(quantity, items[index].Quantity); //meaning we can't sell more than we have

        //We add money according to how many items we sell
        Money += quantity * oneprice;

        //Then we subtract the amount from our inventory
        items[index].Quantity -= quantity;

        //If we sold all of an item, we erase it from the inventory
        if (items[index].Quantity <= 0)
            items.RemoveAt(index);

        //And then we update the UI
        UIManager.Get().UpdateAll();
    }

    // Start is called before the first frame update
    void Start()
    {
        gih = GameInfoHolder.Get();
    }

}
