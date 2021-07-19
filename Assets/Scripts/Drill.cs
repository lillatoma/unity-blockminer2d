using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drill : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Block block = collision.GetComponent<Block>();

        if(block)
        {
            block.AddBreakage(2f);
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
