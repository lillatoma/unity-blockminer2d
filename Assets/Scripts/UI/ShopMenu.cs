using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenu : MonoBehaviour
{
    public GameObject DecideScreen;
    public GameObject BuyScreen;
    public GameObject SellScreen;


    public void OpenScene(int sceneidx)
    {
        //Sets active the currently visible scene, and sets inactive the rest
        DecideScreen.SetActive(sceneidx == 0);
        BuyScreen.SetActive(sceneidx == 1);
        SellScreen.SetActive(sceneidx == 2);

        //If we sell items, we have to prepare the SellPanels
        if (sceneidx == 2)
            SellScreen.GetComponent<UIScene3_Sell>().Begin();
    }

}
