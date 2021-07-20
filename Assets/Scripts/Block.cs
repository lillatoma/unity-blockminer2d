using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int type;
    public bool breaking = false;

    public int blockindex;
    private float delta;
    private float breakPercentage = 0f;

    public void AddBreakage(int drillpower, float dirttime, float oretime)
    {


        GameInfoHolder gih = GameInfoHolder.Get();

        if (drillpower < gih.OreStrength[blockindex])
            return;

        float breaktime = oretime;

        if (Equals(gih.OreName[blockindex], "Dirt"))
            breaktime = dirttime;

        float scale = 1f / breaktime;

        breakPercentage += scale * delta;

        if (breakPercentage >= 1f)
                OnBreak(gih);
            else for (int i = gih.BlockBreakage.Length - 1; i >= 0; i--)
                {
                    if (0.01f * gih.BlockBreakagePercentage[i] < breakPercentage)
                    {
                        foreach (Transform child in transform)
                            Destroy(child.gameObject);

                        GameObject gi = Instantiate(gih.BlockBreakage[i], this.transform.position + new Vector3(0, 0, -0.5f), Quaternion.identity);
                        gi.transform.parent = this.transform;
                        break;
                    }
                }
    }

    public void OnBreak(GameInfoHolder gih) //spawns the item on break. Parameter is for performance saving, I guess
    {
        GameObject gi = Instantiate(gih.NoBlockBlock, this.transform.position, Quaternion.identity);
        gi.transform.parent = transform.parent;

        GameObject it_ent = GameObject.FindGameObjectWithTag("ItemEntities");



        if (gih.OreInvDrawable[blockindex] && gih.OreInvDrawable[blockindex].GetComponent<InventoryItem>())
        {
            GameObject gi_item = Instantiate(gih.OreInvDrawable[blockindex], transform.position + new Vector3(0, 0, -0.5f), Quaternion.identity);
            gi_item.transform.parent = it_ent.transform;
        }
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        delta = Time.deltaTime;
    }
}
