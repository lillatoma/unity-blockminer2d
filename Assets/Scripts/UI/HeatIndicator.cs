using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeatIndicator : MonoBehaviour
{
    public Image panel;
    GameInfoHolder gih;
    Robot robot;


    // Start is called before the first frame update
    void Start()
    {
        //We get the GameInfoHolder and Robot, to reduce unnecessary function calls later
        gih = GameInfoHolder.Get();
        robot = FindObjectOfType<Robot>();
    }

    // Update is called once per frame
    void Update()
    {



        int maxSafeDepth = gih.CoreDepth[robot.coreLevel];

        float yDepth = robot.transform.GetChild((int)E_ROBOT_CHILD.CH_BODY).transform.position.y;
        yDepth = -Mathf.Min(0f, yDepth);

        //We calculate how deep we are on a scale from 0 - 1, >1 values will get compressed to 1
        float percentage = Mathf.Min(1f, yDepth / (maxSafeDepth*gih.BlockDistance));

        byte Red = 0;
        byte Green = 255;
        //We change the color of the thermometer from green (0) to yellow (0.5) to red (1.0)
        if(percentage < 0.5f)
        {
            Red = (byte)(percentage * 510);
        }
        else if (percentage <= 1f)
        {
            Red = 255;
            Green = (byte)(510 - percentage* 510);
        }

        //We change how high the meter is filled according to the percentage
        float panelHeight = percentage * 40f;
        panel.rectTransform.sizeDelta = new Vector2(panel.rectTransform.sizeDelta.x, panelHeight);
        panel.color = new Color32(Red, Green, 0, 255);
    }
}
