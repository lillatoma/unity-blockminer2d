using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScene3_Sell : MonoBehaviour
{
    public GameObject SellPanelPrefab;

    public void Clear()
    {
        foreach(Transform child in transform)
            Destroy(child.gameObject);
    }

    public void Begin()
    {
        Clear();
        Inventory inv = FindObjectOfType<Inventory>();
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
        if(inv.items.Count != transform.childCount)
        {
            Begin();
        }
    }
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RedrawCheck();   
    }
}
