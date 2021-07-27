using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public int index;
    public int Quantity = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If an InventoryItem collides with the Robot, that means the robot picks the item up, if there is still place left
        //To avoid infinite item pickups, we destroy this item
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
