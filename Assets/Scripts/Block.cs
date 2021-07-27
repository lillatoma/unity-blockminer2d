using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int type;
    public bool breaking = false;

    public int blockindex;
    private float breakPercentage = 0f;

    GameInfoHolder gih;

    public void AddBreakage(int drillpower, float dirttime, float oretime, float delta)
    {
        //We only find the GameInfoHolder when we touch the block
        //The reason why is, because getting it on the Start() would result all blocks from a chunk to find GameInfoHolder, which is costy
        //Also, unnecessary since on blocks that are not touched (and will not be touched), finding GameInfoHolder is a waste of time
        if(gih == null)
            gih = GameInfoHolder.Get();

        //If the block is too heavy, we won't damage it
        if (drillpower < gih.OreStrength[blockindex])
            return;

        //On Dirt we use dirttime, else we use oretime
        float breaktime = oretime;
        if (Equals(gih.OreName[blockindex], "Dirt"))
            breaktime = dirttime;

        //We damage the block
        breakPercentage += delta / breaktime;

        if (breakPercentage >= 1f)
                OnBlockBreak(gih); // <-- If the percentage is >=1 (>= 100%), we run code accordingly 
            else for (int i = gih.BlockBreakage.Length - 1; i >= 0; i--)
                {
                    if (0.01f * gih.BlockBreakagePercentage[i] < breakPercentage)
                    {
                        //For now, I didn't have a better idea, and now when I'm commenting, I was lazy to change
                        //We add the block breakage indicator after it hits a certain percentage set in the GameInfoHolder
                        //We also destroy any previous block breakage indicators
                        foreach (Transform child in transform)
                            Destroy(child.gameObject);

                        GameObject gi = Instantiate(gih.BlockBreakage[i], this.transform.position + new Vector3(0, 0, -0.5f), Quaternion.identity);
                        gi.transform.parent = this.transform;
                        break;
                    }
                }
    }

    public void OnBlockBreak(GameInfoHolder gih) //spawns the item on break. Parameter is for performance saving, I guess
    {
        //We place an empty block at the place of the old, now broken block
        GameObject gi = Instantiate(gih.NoBlockBlock, this.transform.position, Quaternion.identity);
        gi.transform.parent = transform.parent;

        //For better hierarchy management, we use a GameObject to contain the items that were dropped, and aren't picked up yet.
        GameObject it_ent = GameObject.FindGameObjectWithTag("ItemEntities");


        //If the block has an item ordered to it, we instantiate a collectable item at the position of the old block.
        if (gih.OreInvDrawable[blockindex] && gih.OreInvDrawable[blockindex].GetComponent<InventoryItem>())
        {
            GameObject gi_item = Instantiate(gih.OreInvDrawable[blockindex], transform.position + new Vector3(0, 0, -0.5f), Quaternion.identity);
            gi_item.transform.parent = it_ent.transform;
        }
        //Finally, we destroy the old block.
        Destroy(this.gameObject);
    }
}
