using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour
{
    public List<InventoryItem> items;
    public int Money = 0;
    

    public int CalculateLoad()
    {


        int load = 0;
        foreach (InventoryItem item in items)
            load += item.Quantity;

        return load;
    }
    public bool IsFull()
    {
        GameInfoHolder gih = GameInfoHolder.Get();
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
        GameInfoHolder gih = GameInfoHolder.Get();

        int oneprice = gih.OrePrice[items[index].index];

        if (quantity == -1)
            quantity = items[index].Quantity;
        else quantity = Mathf.Min(quantity, items[index].Quantity); //meaning we can't sell more than we have


        Money += quantity * oneprice;

        items[index].Quantity -= quantity;

        if (items[index].Quantity <= 0)
            items.RemoveAt(index);

        UIManager.Get().UpdateAll();
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
