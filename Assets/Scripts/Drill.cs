using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drill : MonoBehaviour
{
    GameInfoHolder gih;
    float delta;
    // Start is called before the first frame update
    void Start()
    {
        gih = GameInfoHolder.Get();
    }

    // Update is called once per frame
    void Update()
    {
        delta = Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Block block = collision.GetComponent<Block>();

        if(block)
        {
            int drillLevel = transform.parent.GetComponent<Robot>().drillLevel;
            int drillPower = gih.DrillPower[drillLevel];
            float drillTimeDirt = gih.DrillTimeOnDirt[drillLevel];
            float drillTimeOre = gih.DrillTimeOnOre[drillLevel];

            block.AddBreakage(drillPower, drillTimeDirt, drillTimeOre, delta);
            delta = 0f;
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    Block block = collision.GetComponent<Block>();

    //    if(block)
    //    {
    //        Debug.Log("Block started breaking");
    //        block.breaking = true;
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    Block block = collision.GetComponent<Block>();

    //    if (block)
    //    {
    //        block.breaking = false;
    //        Debug.Log("Block stopped breaking");
    //    }
    //}
}
