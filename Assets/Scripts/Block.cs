using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public bool unbreakable;
    public int type;
    public bool breaking = false;

    private float delta;
    private float breakPercentage = 0f;

    public void AddBreakage(float scale)
    {
        if (unbreakable) return;
        {
            breakPercentage += scale * delta;

            GameInfoHolder gih = GameObject.FindObjectOfType<GameInfoHolder>();

            if(breakPercentage >= 1f)
            {
                GameObject gi = Instantiate(gih.NoBlockBlock, this.transform.position, Quaternion.identity);
                gi.transform.parent = transform.parent;
                Destroy(this.gameObject);
            }
            else for (int i = gih.BlockBreakage.Length - 1; i >= 0; i--)
                {
                    if (0.01f*gih.BlockBreakagePercentage[i] < breakPercentage)
                    {
                        foreach (Transform child in transform)
                            Destroy(child.gameObject);

                        GameObject gi = Instantiate(gih.BlockBreakage[i], this.transform.position + new Vector3(0,0,-0.5f), Quaternion.identity);
                        gi.transform.parent = this.transform;
                        break;
                    }
                }
        }
    }

    // Update is called once per frame
    void Update()
    {
        delta = Time.deltaTime;
    }
}
