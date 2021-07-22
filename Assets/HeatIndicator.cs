using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeatIndicator : MonoBehaviour
{
    public Image panel;
    GameInfoHolder gih;



    // Start is called before the first frame update
    void Start()
    {
       gih = GameInfoHolder.Get();
    }

    // Update is called once per frame
    void Update()
    {
        Robot robot = FindObjectOfType<Robot>();


        int maxSafeDepth = gih.CoreDepth[robot.coreLevel];

        float yDepth = robot.transform.GetChild((int)E_ROBOT_CHILD.CH_BODY).transform.position.y;
        yDepth = -Mathf.Min(0f, yDepth);

        float percentage = Mathf.Min(1f, yDepth / (maxSafeDepth*gih.BlockDistance));

        byte Red = 0;
        byte Green = 255;

        if(percentage < 0.5f)
        {
            Red = (byte)(percentage * 510);
        }
        else if (percentage <= 1f)
        {
            Red = 255;
            Green = (byte)(510 - percentage* 510);
        }

        float panelHeight = percentage * 40f;

        panel.rectTransform.sizeDelta = new Vector2(panel.rectTransform.sizeDelta.x, panelHeight);
        panel.color = new Color32(Red, Green, 0, 255);
    }
}
