using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MoneyText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TextUpdate()
    {
        Inventory inv = GameObject.FindObjectOfType<Inventory>();
        Text t = GetComponent<Text>();
        t.text = "$  " + inv.Money;

    }
}
