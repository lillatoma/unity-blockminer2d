using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    public int chunkindex;

    //Function that uses the GameInfoHolder object to set up a singular block according to its Y position
    //Places it according to its parent chunk and X position respecting its parent block's world position
    public void SetupBlock(int x, int y, GameInfoHolder gih)
    {
        int r = Random.Range(0, 10000);

        int totalcount = 0;

        //This loop might be uneasy to grasp first
        //Since we don't know how many blocktypes are in the game, we use a for loop to check each of them
        //Important note: For now block #0 should always be bedrock (Q#1)
        for (int i = 0; i < gih.OreSpawnPercentage.Length; i++)
        {
            //First, if the checked ore is too deep compared to our block, we simply skip forward
            if (y < gih.OreDepth[i]) continue;

            //Now if the ore is not too deep, we add it to our totalcount counter
            totalcount += (int)(100f * gih.OreSpawnPercentage[i]);
            //If the totalcount exceeds r, that means that we finally found which ore is needed
            //If y is too high, that means that its high at (i==0) resulting the block being a bedrock (Q#1)
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

    //Function that generates a whole chunk.
    IEnumerator GenerateChunk()
    {
        //We delay chunk generating because we want to set chunkindex first
        yield return new WaitForSeconds(.1f);
        transform.position = new Vector3(chunkindex * 16*32, 0, 0);

        //We find GameInfoHolder, so we can use it as a parameter for SetupBlock(...)
        //The reason why we use it outside here, is because we save X*Y-1 costy calculations
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
        //We start GenerateChunk();
        StartCoroutine(GenerateChunk());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If the camera's collider hits the chunk's collider, we set the whole chunk visible.
        if (collision.tag == "MainCamera")
        {
            foreach (Transform child in transform)
                child.transform.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //If the camera's collider leaves the chunk's collider, we set the whole chunk invisible.
        //We don't want to render tonnes of objects that aren't even on the screen
        if (collision.tag == "MainCamera")
        {
            foreach (Transform child in transform)
                child.transform.gameObject.SetActive(false);
        }
    }

}
