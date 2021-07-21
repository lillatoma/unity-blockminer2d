using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public GameObject TheShopMenu;

    public void OpenShopMenu()
    {
        TheShopMenu.SetActive(true);
    }

    public void CloseShopMenu()
    {
        TheShopMenu.GetComponent<ShopMenu>().OpenScene(0);
        TheShopMenu.SetActive(false);
        
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
