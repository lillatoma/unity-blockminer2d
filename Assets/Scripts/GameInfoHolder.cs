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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
