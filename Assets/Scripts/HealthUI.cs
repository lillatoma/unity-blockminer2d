using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void UpdateThis(int health)
    {
        //This function basically changes the text and color with the help of a gradient from green (100HP) to yellow (50HP) to red (0HP)
        float convertHealth = (float)health;

        byte Red = (byte)(510f - 5.1f*convertHealth);
        byte Green = 255;

        if(health < 50)
        {
            Red = 255;
            Green = (byte)(5.1f * convertHealth);
        }


        Color32 nColor = new Color32(Red, Green, 0, 255);

        GetComponent<Image>().color = nColor;
        transform.GetChild(0).GetComponent<Text>().text = health.ToString();
        transform.GetChild(0).GetComponent<Text>().color = nColor;
    }

}
