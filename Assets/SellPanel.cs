using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellPanel : MonoBehaviour
{
    public int InventoryIndex = 0;
    public Image image;
    public Text text;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Refresh();
    
    }

    public void Refresh()
    {
        GameInfoHolder gih = GameInfoHolder.Get();
        Inventory inv = GameObject.FindObjectOfType<Inventory>();


        image.sprite = gih.OreInvDrawable[inv.items[InventoryIndex].index].GetComponent<SpriteRenderer>().sprite;
        text.text = gih.OreName[inv.items[InventoryIndex].index] + " (" + inv.items[InventoryIndex].Quantity + " | $" + gih.OrePrice[inv.items[InventoryIndex].index] + ")";



    }

    public void SellOne()
    {
        GameObject.FindObjectOfType<Inventory>().SellItem(InventoryIndex);
    }

    public void SellAll()
    {
        GameObject.FindObjectOfType<Inventory>().SellItem(InventoryIndex, -1);
    }
}
