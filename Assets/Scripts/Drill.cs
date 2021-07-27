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
        //Since OnTrigger...(...) functions are called randomly, we want to ensure that we always have the correct frametime
        delta = Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Block block = collision.GetComponent<Block>();

        //We only want to do anything if the drill collides with a block
        if(block)
        {
            //We get the drill data according to the drillLevel
            int drillLevel = transform.parent.GetComponent<Robot>().drillLevel;
            int drillPower = gih.DrillPower[drillLevel];
            float drillTimeDirt = gih.DrillTimeOnDirt[drillLevel];
            float drillTimeOre = gih.DrillTimeOnOre[drillLevel];

            //Then we add breakage to the block
            block.AddBreakage(drillPower, drillTimeDirt, drillTimeOre, delta);

            //Since OnTriggerStay2D(...) is called randomly, we want to ensure that we only apply breakage once per frame
            delta = 0f;
        }
    }

}
