using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ChunkManager : MonoBehaviour
{
    public GameObject ChunkDefault;
    public GameObject LeftCollider;
    public GameObject RightCollider;


    private int LeftChunk = 0;
    private int RightChunk = 0;

    //Unused function that was used to slow down chunk generation when it was slow to generate a chunk
    public int GetTotalChunks()
    {
        return RightChunk - LeftChunk + 1;
    }

    static public ChunkManager Get()
    {
        //Function to find the supposed only ChunkManager object
        return FindObjectOfType<ChunkManager>();
    }

    //This function generates a chunk to the position of the left collider, and pushes the left collider further
    public void AddLeftChunk()
    {
        LeftChunk --;
        GameObject chunk = Instantiate(ChunkDefault);
        chunk.GetComponent<Chunk>().chunkindex = LeftChunk;
        chunk.gameObject.SetActive(true);
        LeftCollider.transform.position = new Vector3(LeftCollider.transform.position.x - 16 * GameInfoHolder.Get().BlockDistance, LeftCollider.transform.position.y, LeftCollider.transform.position.z);
        
    }
    //This function generates a chunk to the position of the right collider, and pushes the right collider further
    public void AddRightChunk()
    {
        RightChunk ++;
        GameObject chunk = Instantiate(ChunkDefault);
        chunk.GetComponent<Chunk>().chunkindex = RightChunk;
        chunk.gameObject.SetActive(true);
        RightCollider.transform.position = new Vector3(RightCollider.transform.position.x + 16 * GameInfoHolder.Get().BlockDistance, RightCollider.transform.position.y, RightCollider.transform.position.z);

    }



    // Start is called before the first frame update
    void Start()
    {
        //Setting up chunk #0
        GameObject chunk = Instantiate(ChunkDefault);
        chunk.gameObject.SetActive(true);
        chunk.GetComponent<Chunk>().chunkindex = 0;
    }

}
