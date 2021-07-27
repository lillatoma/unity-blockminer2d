using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScene3_Sell : MonoBehaviour
{
    public GameObject SellPanelPrefab;

    public void Clear()
    {
        //Destroys all SellOanels
        foreach(Transform child in transform)
            Destroy(child.gameObject);
    }

    public void Begin()
    {
        //Destroy any previous SellPanels
        Clear();
        Inventory inv = FindObjectOfType<Inventory>();

        //For each item we create a new SellPanel
        for(int i = 0; i < inv.items.Count; i++)
        {
            GameObject sellpanel = Instantiate(SellPanelPrefab, new Vector3(), Quaternion.identity);
            sellpanel.GetComponent<SellPanel>().InventoryIndex = i;
            sellpanel.GetComponent<SellPanel>().Refresh();
            sellpanel.transform.parent = transform;
            sellpanel.transform.localPosition = Vector3.zero;
            sellpanel.transform.position = transform.position + new Vector3(0, 64 - i * 20, 0);
        }
    }

    public void RedrawCheck()
    {
        Inventory inv = FindObjectOfType<Inventory>();
        //If we sold all our items, or (somehow) picked up a new item in the shop area, we Begin()
        if(inv.items.Count != transform.childCount)
        {
            Begin();
        }
    }

    // Update is called once per frame
    void Update()
    {
        RedrawCheck();   
    }
}
