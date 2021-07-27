using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScene2_Buy : MonoBehaviour
{
    public Text DrillText;
    public Button DrillButton;
    public Text BackpackText;
    public Button BackpackButton;
    public Text CoreText;
    public Button CoreButton;

    // Start is called before the first frame update
    void Start()
    {
        //We update immediately so everything loads up correctly in the first frame
        Update();
    }

    // Update is called once per frame
    void Update()
    {
        GameInfoHolder gih = GameInfoHolder.Get();
        Robot rob = GameObject.FindObjectOfType<Robot>();

        Color32 GoodColor = new Color32(64, 192, 64, 255);
        Color32 BadColor = new Color32(128, 44, 64, 255);


        //Then for each upgradable item we change the button text and the button color, and the text next to the button

        //Drill
        DrillText.text = "Drill Level " + rob.drillLevel + " - " + gih.DrillName[rob.drillLevel];
        DrillButton.GetComponent<Image>().color = GoodColor;
        if (rob.drillLevel == gih.DrillName.Length - 1)
            DrillButton.transform.GetChild(0).GetComponent<Text>().text = "MAX";
        else
        {
            if (rob.GetComponent<Inventory>().Money < gih.DrillPrice[rob.drillLevel + 1])
                DrillButton.GetComponent<Image>().color = BadColor;
            DrillButton.transform.GetChild(0).GetComponent<Text>().text = "$" + gih.DrillPrice[rob.drillLevel + 1];
        }

        //Backpack
        BackpackText.text = "Backpack Level " + rob.backpackLevel + " - " + gih.BackpackName[rob.backpackLevel];
        BackpackButton.GetComponent<Image>().color = GoodColor;
        if (rob.backpackLevel == gih.BackpackName.Length - 1)
            BackpackButton.transform.GetChild(0).GetComponent<Text>().text = "MAX";
        else
        {
            if (rob.GetComponent<Inventory>().Money < gih.BackpackPrice[rob.backpackLevel + 1])
                BackpackButton.GetComponent<Image>().color = BadColor;
            BackpackButton.transform.GetChild(0).GetComponent<Text>().text = "$" + gih.BackpackPrice[rob.backpackLevel + 1];
        }
        //Core
        CoreText.text = "ThermoCore Level " + rob.coreLevel + " - " + gih.CoreName[rob.coreLevel];
        CoreButton.GetComponent<Image>().color = GoodColor;
        if (rob.coreLevel == gih.CoreName.Length - 1)
            CoreButton.transform.GetChild(0).GetComponent<Text>().text = "MAX";
        else
        {
            if (rob.GetComponent<Inventory>().Money < gih.CorePrice[rob.coreLevel + 1])
                CoreButton.GetComponent<Image>().color = BadColor;
            CoreButton.transform.GetChild(0).GetComponent<Text>().text = "$" + gih.CorePrice[rob.coreLevel + 1];
        }
    }
}
