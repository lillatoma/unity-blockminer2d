using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkCollider : MonoBehaviour
{
    public bool IsLeft = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "MainCamera")
        {
            if (IsLeft)
                ChunkManager.Get().AddLeftChunk();
            else
                ChunkManager.Get().AddRightChunk();
        }
    }

}
