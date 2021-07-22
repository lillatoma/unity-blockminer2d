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
        chunk.gameObject.SetActive(true);
        LeftCollider.transform.position = new Vector3(LeftCollider.transform.position.x - 16 * GameInfoHolder.Get().BlockDistance, LeftCollider.transform.position.y, LeftCollider.transform.position.z);
        
    }

    public void AddRightChunk()
    {
        RightChunk ++;
        GameObject chunk = Instantiate(ChunkDefault);
        chunk.GetComponent<Chunk>().chunkindex = RightChunk;
        chunk.gameObject.SetActive(true);
        RightCollider.transform.position = new Vector3(RightCollider.transform.position.x + 16 * GameInfoHolder.Get().BlockDistance, RightCollider.transform.position.y, RightCollider.transform.position.z);

    }

    void PrepareChunk()
    {

        for (int i = 0; i < 16 * 80; i++)
        {
            GameObject undecided = Instantiate(GameInfoHolder.Get().OreDrawable[0],new Vector3(i*64f,512f,0f),Quaternion.identity);
            undecided.name = "Undecided";
            undecided.SetActive(false);
            undecided.transform.parent = ChunkDefault.transform;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        //PrepareChunk();
        
        //Setting up chunk #0
        GameObject chunk = Instantiate(ChunkDefault);
        chunk.gameObject.SetActive(true);
        chunk.GetComponent<Chunk>().chunkindex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float aspectRatio = (float)Screen.width / (float)Screen.height;
        float totalBlocksOnScreenHorizontal = 450f / 32f * aspectRatio;


    }
}
