using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameInfoHolder : MonoBehaviour
{
    [Header("Ore Data")]
    public string[] OreName;
    public float[] OreSpawnPercentage;
    public int[] OreDepth;
    public GameObject[] OreDrawable;
    public GameObject[] OreInvDrawable;
    public int[] OrePrice;

    [Header("Block Breakage")]
    public GameObject[] BlockBreakage;
    public float[] BlockBreakagePercentage;
    public GameObject NoBlockBlock;

    [Header("Other")]
    public float BlockDistance;


    // Start is called before the first frame update
    void Start()
    {
        //Assign item indexes to Inventory Item objects according to their array index
        for (int i = 0; i < OreInvDrawable.Length; i++)
        {
            if (OreInvDrawable[i] && OreInvDrawable[i].GetComponent<InventoryItem>()) //if the object is assigned in the inspector and is an inventory item
                OreInvDrawable[i].GetComponent<InventoryItem>().index = i;

        }

        //Similarly to Inventory Item, but with blocks
        for(int i = 0; i < OreDrawable.Length; i++)
        {
            if (OreDrawable[i] && OreDrawable[i].GetComponent<Block>())
                OreDrawable[i].GetComponent<Block>().blockindex = i; //This is later used for block breaks in order to spawn the correct item that can be picked up
        }

        //PS: I'm too lazy to do assign 22~ numbers, so I do it with code :/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
