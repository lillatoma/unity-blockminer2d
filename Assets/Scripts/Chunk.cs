using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    public int chunkindex;

    public void SetupBlock(int x, int y, GameInfoHolder gih)
    {
        int r = Random.Range(0, 10000);

        int totalcount = 0;
        for (int i = 0; i < gih.OreSpawnPercentage.Length; i++)
        {
            if (y < gih.OreDepth[i]) continue;
            totalcount += (int)(100f * gih.OreSpawnPercentage[i]);
            if (totalcount > r || y >= 64)
            {
                GameObject derivedDrawable = GameObject.Instantiate(gih.OreDrawable[i]);
                derivedDrawable.transform.parent = transform;
                derivedDrawable.transform.localPosition = new Vector2(x * gih.BlockDistance, -y * gih.BlockDistance);
                derivedDrawable.GetComponent<Block>().type = i;

                break;
            }
        }


    }
    IEnumerator GenerateChunk(int totalChunks)
    {
        yield return new WaitForSeconds(.1f);
        transform.position = new Vector3(chunkindex * 16*32, 0, 0);

        GameInfoHolder gih = GameInfoHolder.Get();

        for (int x = 0; x < 16; x++)
        {
            for (int y = 0; y < 80; y++)
            {
                SetupBlock(x, y, gih);
            }
        }
        
    }


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenerateChunk(ChunkManager.Get().GetTotalChunks()));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "MainCamera")
        {
            foreach (Transform child in transform)
                child.transform.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "MainCamera")
        {
            foreach (Transform child in transform)
                child.transform.gameObject.SetActive(false);
        }
    }

}
