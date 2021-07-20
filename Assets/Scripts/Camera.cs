using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Robot rob = GameObject.FindObjectOfType<Robot>();
        transform.position = rob.transform.GetChild((int)E_ROBOT_CHILD.CH_BODY).transform.position + new Vector3(0,0,-9f);
    }
}
