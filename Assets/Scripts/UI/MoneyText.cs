using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MoneyText : MonoBehaviour
{


    public void TextUpdate()
    {
        //Straightforward: we update the text of the money indicator to show how much money is in our inventory
        Inventory inv = GameObject.FindObjectOfType<Inventory>();
        Text t = GetComponent<Text>();
        t.text = "$  " + inv.Money;

    }
}
