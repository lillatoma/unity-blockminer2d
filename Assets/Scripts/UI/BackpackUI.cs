using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackpackUI : MonoBehaviour
{

    
    public void UpdateThis(int load, int totalLoad)
    {
        //This function basically changes the text and color with the help of a gradient from green (100HP) to yellow(0HP)
        float convertLoad = (float)load;

        byte Red = (byte)(2.55f * convertLoad);

        Color32 nColor = new Color32(Red, 255, 0, 255);

        GetComponent<Image>().color = nColor;
        transform.GetChild(0).GetComponent<Text>().text = load.ToString() + "/" + totalLoad;
        transform.GetChild(0).GetComponent<Text>().color = nColor;
    }

}
