using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIManager : MonoBehaviour
{
    MoneyText moneyText;
    BackpackUI backpackUI;
    HealthUI healthUI;

    //Updates almost all UI elements. HeatIndicator is always updated, so it's not updated here
    public void UpdateAll()
    {
        GameInfoHolder gih = GameInfoHolder.Get();
        Robot rob = GameObject.FindObjectOfType<Robot>();
        moneyText.TextUpdate();
        backpackUI.UpdateThis(rob.gameObject.GetComponent<Inventory>().CalculateLoad(), gih.BackpackCapacity[rob.backpackLevel]);
        healthUI.UpdateThis(rob.Health);

    }

    // Start is called before the first frame update
    void Start()
    {
        moneyText = GameObject.FindObjectOfType<MoneyText>();
        backpackUI = GameObject.FindObjectOfType<BackpackUI>();
        healthUI = GameObject.FindObjectOfType<HealthUI>();
    }

    public static UIManager Get()
    {
        //Returns the supposed only UIManager
        return GameObject.FindObjectOfType<UIManager>();
    }

}
