using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    public int chunkindex;

    public void SetupBlock(int x, int y)
    {
        GameInfoHolder gih = GameInfoHolder.Get();

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
    IEnumerator GenerateChunk(int chunkindex)
    {
        yield return new WaitForSeconds(.25f);
        transform.position = new Vector3(chunkindex * 16*32, 0, 0);

        for (int x = 0; x < 16; x++)
            for (int y = 0; y < 80; y++)
            {
                SetupBlock(x, y);
            } 
    }


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenerateChunk(chunkindex));
        StopCoroutine(GenerateChunk(chunkindex));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
