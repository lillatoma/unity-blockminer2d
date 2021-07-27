using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellPanel : MonoBehaviour
{
    public int InventoryIndex = 0;
    public Image image;
    public Text text;

    // Update is called once per frame
    void Update()
    {
        Refresh();
    
    }

    public void Refresh()
    {
        GameInfoHolder gih = GameInfoHolder.Get();
        Inventory inv = GameObject.FindObjectOfType<Inventory>();

        //We change the sprite and text of the panel
        image.sprite = gih.OreInvDrawable[inv.items[InventoryIndex].index].GetComponent<SpriteRenderer>().sprite;
        text.text = gih.OreName[inv.items[InventoryIndex].index] + " (" + inv.items[InventoryIndex].Quantity + " | $" + gih.OrePrice[inv.items[InventoryIndex].index] + ")";



    }

    public void SellOne()
    {
        //Sells one item
        GameObject.FindObjectOfType<Inventory>().SellItem(InventoryIndex);
    }

    public void SellAll()
    {
        //Sells all items, -1 meaning all items
        GameObject.FindObjectOfType<Inventory>().SellItem(InventoryIndex, -1);
    }
}
