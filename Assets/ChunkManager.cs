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

    public int GetTotalChunks()
    {
        return RightChunk - LeftChunk + 1;
    }

    static public ChunkManager Get()
    {
        return FindObjectOfType<ChunkManager>();
    }

    public void AddLeftChunk()
    {
        LeftChunk --;
        GameObject chunk = Instantiate(ChunkDefault);
        chunk.GetComponent<Chunk>().chunkindex = LeftChunk;

        LeftCollider.transform.position = new Vector3(LeftCollider.transform.position.x - 16 * GameInfoHolder.Get().BlockDistance, LeftCollider.transform.position.y, LeftCollider.transform.position.z);
    
    }

    public void AddRightChunk()
    {
        RightChunk ++;
        GameObject chunk = Instantiate(ChunkDefault);
        chunk.GetComponent<Chunk>().chunkindex = RightChunk;

        RightCollider.transform.position = new Vector3(RightCollider.transform.position.x + 16 * GameInfoHolder.Get().BlockDistance, RightCollider.transform.position.y, RightCollider.transform.position.z);

    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject chunk = Instantiate(ChunkDefault);
        chunk.GetComponent<Chunk>().chunkindex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float aspectRatio = (float)Screen.width / (float)Screen.height;
        float totalBlocksOnScreenHorizontal = 450f / 32f * aspectRatio;


    }
}
