using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    public int chunkindex;

    public void SetupBlock(int x, int y)
    {
        GameInfoHolder gih = GameObject.FindObjectOfType<GameInfoHolder>();

        int r = Random.Range(0, 10000);

        int totalcount = 0;
        for (int i = 0; i < gih.OreSpawnPercentage.Length; i++)
        {
            if (y < gih.OreDepth[i]) continue;
            totalcount += (int)(100f * gih.OreSpawnPercentage[i]);
            if (totalcount > r || y >= 64)
            {
                GameObject derivedDrawable = GameObject.Instantiate(gih.OreDrawable[i], new Vector2(x * gih.BlockDistance, -y * gih.BlockDistance), Quaternion.identity);
                derivedDrawable.transform.parent = transform;
                derivedDrawable.GetComponent<Block>().type = i;
                derivedDrawable.GetComponent<Block>().unbreakable = Equals(gih.OreName[i], "Bedrock");
                break;
            }
        }


    }
    IEnumerator GenerateChunk(int chunkindex)
    {
        yield return new WaitForSeconds(1);
        transform.position = new Vector3(chunkindex * 16, 0, 0);

        for (int x = 0; x < 16; x++)
            for (int y = 0; y < 80; y++)
            {
                SetupBlock(x, y);
            } 
    }


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenerateChunk(0));
        StopCoroutine(GenerateChunk(0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
