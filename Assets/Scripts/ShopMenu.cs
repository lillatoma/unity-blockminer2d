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
        DecideScreen.SetActive(sceneidx == 0);
        BuyScreen.SetActive(sceneidx == 1);
        SellScreen.SetActive(sceneidx == 2);

        if (sceneidx == 2)
            SellScreen.GetComponent<UIScene3_Sell>().Begin();
    }


    /////////////////////////////////////////
    ///             SCENE 1              ///
    ///////////////////////////////////////




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
