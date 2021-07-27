using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkCollider : MonoBehaviour
{
    public bool IsLeft = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //This is used for chunk generation
        //If the camera's collider hits one with (IsLeft == true), we generate a new chunk towards the left
        //Else, towards the right
        if(collision.tag == "MainCamera")
        {
            if (IsLeft)
                ChunkManager.Get().AddLeftChunk();
            else
                ChunkManager.Get().AddRightChunk();
        }
    }

}
