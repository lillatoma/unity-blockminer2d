using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameInfoHolder : MonoBehaviour
{
    [Header("Ore Data")]
    public string[] OreName;
    public float[] OreSpawnPercentage;
    public int[] OreDepth;
    public int[] OreStrength;
    public GameObject[] OreDrawable;
    public GameObject[] OreInvDrawable;
    public int[] OrePrice;

    [Header("Block Breakage")]
    public GameObject[] BlockBreakage;
    public float[] BlockBreakagePercentage;
    public GameObject NoBlockBlock;

    [Header("Drill Information")]
    public string[] DrillName;
    public int[] DrillPrice;
    public int[] DrillPower;
    public float[] DrillTimeOnDirt;
    public float[] DrillTimeOnOre;

    [Header("Backpack Information")]
    public string[] BackpackName;
    public int[] BackpackCapacity;
    public int[] BackpackPrice;

    [Header("ThermoCore Information")]
    public string[] CoreName;
    public int[] CoreDepth;
    public int[] CorePrice;

    [Header("Other")]
    public float BlockDistance;
    public float MoneyTakeOnDeathPercentage;


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

    public static GameInfoHolder Get()
    {
        return GameObject.FindObjectOfType<GameInfoHolder>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
