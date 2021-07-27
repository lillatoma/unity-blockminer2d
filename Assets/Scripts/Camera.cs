using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    Robot rob;

    private void Start()
    {
        rob = GameObject.FindObjectOfType<Robot>();
    }
    void Update()
    {
        //We center the camera to the robot's position, so it follows the robot
        transform.position = rob.transform.GetChild((int)E_ROBOT_CHILD.CH_BODY).transform.position + new Vector3(0,0,-9f);
    }
}
