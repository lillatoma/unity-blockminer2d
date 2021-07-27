using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //If the robot leaves the shop area, we close the shop menu
        if (collision.tag == "RobotObject")
            GameObject.FindObjectOfType<ShopManager>().CloseShopMenu();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If the robot enters the shop area and the user holds Space, we open the shop menu
        if (collision.tag == "RobotObject" && Input.GetKey(KeyCode.Space))
            GameObject.FindObjectOfType<ShopManager>().OpenShopMenu();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //If the robot is in the shop area and the user holds Space, we open the shop menu
        if (collision.tag == "RobotObject" && Input.GetKey(KeyCode.Space)) 
            GameObject.FindObjectOfType<ShopManager>().OpenShopMenu();
    }
}
