using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public int index;
    public int Quantity = 1;




    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "RobotObject")
        {
            Inventory inv = GameObject.FindObjectOfType<Inventory>();

            if (inv && !inv.IsFull())
            {
                inv.AddInventoryItem(this);
                UIManager.Get().UpdateAll();
                Destroy(this.gameObject);
            }
        }
    }
}
