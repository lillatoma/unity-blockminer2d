using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum E_ROBOT_MOVEMENT_DIR
{
    MOVE_LEFT = 0,
    MOVE_RIGHT,
    MOVE_UP,
    MOVE_DOWN
}

public enum E_ROBOT_CHILD
{
    CH_BODY,
    CH_DRILL
}

public class Robot : MonoBehaviour
{
    public int Health = 100;

    [Header("Robot - Robot")]
    public GameObject robotLeft;
    public GameObject robotRight;
    public GameObject robotUp;
    public GameObject robotDown;

    [Header("Robot - Drill")]
    public GameObject drillLeft;
    public GameObject drillRight;
    public GameObject drillUp;
    public GameObject drillDown;
    public Vector2 drillLeftOffset;
    public Vector2 drillRightOffset;
    public Vector2 drillUpOffset;
    public Vector2 drillDownOffset;

    [Header("Robot - Attributes")]

    public int drillLevel = 0;
    public int backpackLevel = 0;
    public int coreLevel = 0;
    public float moveSpeed;


    private int moveDirection = (int)E_ROBOT_MOVEMENT_DIR.MOVE_LEFT;


    public void Upgrade(int what)
    {
        Inventory inv = GetComponent<Inventory>();
        GameInfoHolder gih = GameInfoHolder.Get();

        if (what == 0) //Drill
        {
            //If there is still an upgrade left, and we can afford it, we buy the upgrade, and update the UI
            if(drillLevel + 1 < gih.DrillPrice.Length && inv.Money >= gih.DrillPrice[drillLevel + 1])
            {
                inv.Money -= gih.DrillPrice[drillLevel + 1];
                drillLevel++;
                UIManager.Get().UpdateAll();
            }
        }
        else if (what == 1) //Backpack
        {
            //If there is still an upgrade left, and we can afford it, we buy the upgrade, and update the UI
            if (backpackLevel + 1 < gih.BackpackPrice.Length && inv.Money >= gih.BackpackPrice[backpackLevel + 1])
            {
                inv.Money -= gih.BackpackPrice[backpackLevel + 1];
                backpackLevel++;
                UIManager.Get().UpdateAll();
            }
        }
        else //ThermoCore
        {
            //If there is still an upgrade left, and we can afford it, we buy the upgrade, and update the UI
            if (coreLevel + 1 < gih.CorePrice.Length && inv.Money >= gih.CorePrice[coreLevel + 1])
            {
                inv.Money -= gih.CorePrice[coreLevel + 1];
                coreLevel++;
                UIManager.Get().UpdateAll();
            }
        }
    }

    //Disturbing naming, but it does what it does
    private void DestroyChildren()
    {
        for(int i = transform.childCount - 1; i>= 0; i--)
            DestroyImmediate(transform.GetChild(i).gameObject);
    }

    private void RotateRobot()
    {
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal"); 

        //We save the originalposition of the robot
        Vector3 originalPos = transform.GetChild((int)E_ROBOT_CHILD.CH_BODY).transform.position;

        if (h > 0)
        {
            if (moveDirection != (int)E_ROBOT_MOVEMENT_DIR.MOVE_RIGHT) //If we move right, but we aren't facing right, we reconstruct our robot and our drill facing right
            {
                DestroyChildren();
                GameObject R = Instantiate(robotRight, originalPos, Quaternion.identity);
                GameObject D = Instantiate(drillRight, originalPos + new Vector3(drillRightOffset.x, drillRightOffset.y, 0), Quaternion.identity);
                R.transform.parent = gameObject.transform;
                D.transform.parent = gameObject.transform;
                moveDirection = (int)E_ROBOT_MOVEMENT_DIR.MOVE_RIGHT;
            }
        }
        else if (h < 0)
        {
            if (moveDirection != (int)E_ROBOT_MOVEMENT_DIR.MOVE_LEFT) //If we move left, but we aren't facing left, we reconstruct our robot and our drill facing left
            {
                DestroyChildren();
                GameObject R = Instantiate(robotLeft, originalPos, Quaternion.identity);
                GameObject D = Instantiate(drillLeft, originalPos + new Vector3(drillLeftOffset.x, drillLeftOffset.y, 0), Quaternion.identity);
                R.transform.parent = gameObject.transform;
                D.transform.parent = gameObject.transform;
                moveDirection = (int)E_ROBOT_MOVEMENT_DIR.MOVE_LEFT;
            }
        }
        else if (v < 0)
        {
            if (moveDirection != (int)E_ROBOT_MOVEMENT_DIR.MOVE_DOWN) //If we move down, but we aren't facing down, we reconstruct our robot and our drill facing down
            {
                DestroyChildren();
                GameObject R = Instantiate(robotDown, originalPos, Quaternion.identity);
                GameObject D = Instantiate(drillDown, originalPos + new Vector3(drillDownOffset.x, drillDownOffset.y, 0), Quaternion.identity);
                R.transform.parent = gameObject.transform;
                D.transform.parent = gameObject.transform;
                moveDirection = (int)E_ROBOT_MOVEMENT_DIR.MOVE_DOWN;
            }
        }
        else if (v > 0)
        {
            if (moveDirection != (int)E_ROBOT_MOVEMENT_DIR.MOVE_UP) //If we move up, but we aren't facing up, we reconstruct our robot and our drill facing up
            {
                DestroyChildren();
                GameObject R = Instantiate(robotUp, originalPos, Quaternion.identity);
                GameObject D = Instantiate(drillUp, originalPos + new Vector3(drillUpOffset.x, drillUpOffset.y, 0), Quaternion.identity);
                R.transform.parent = gameObject.transform;
                D.transform.parent = gameObject.transform;
                moveDirection = (int)E_ROBOT_MOVEMENT_DIR.MOVE_UP;
            }
        }

    }

    private void MoveRobot()
    {
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");

        //Left, right, down, up
        Vector2[] Dirs = { new Vector2(-moveSpeed,0),new Vector2(moveSpeed,0), new Vector2(0,moveSpeed), new Vector2(0,-moveSpeed)};
        Vector3[] Offsets = { new Vector3(drillLeftOffset.x, drillLeftOffset.y, 0), new Vector3(drillRightOffset.x, drillRightOffset.y, 0), new Vector3(drillUpOffset.x, drillUpOffset.y, 0), new Vector3(drillDownOffset.x, drillDownOffset.y, 0) };


        for(int i = 0; i < 4; i++)
            if (moveDirection == i)
            {
                //If there is input, we update the velocity of our robot
                if (v != 0 || h != 0) transform.GetChild((int)E_ROBOT_CHILD.CH_BODY).GetComponent<Rigidbody2D>().velocity = Dirs[i];
                transform.GetChild((int)E_ROBOT_CHILD.CH_DRILL).transform.position = transform.GetChild((int)E_ROBOT_CHILD.CH_BODY).transform.position + Offsets[i];

            }

        //If the robot is on the surface, we don't want it to fly, we stop it
        if(moveDirection == (int)E_ROBOT_MOVEMENT_DIR.MOVE_UP && transform.GetChild((int)E_ROBOT_CHILD.CH_BODY).transform.position.y > 32f)
        {
            transform.GetChild((int)E_ROBOT_CHILD.CH_BODY).transform.position = new Vector3(transform.GetChild((int)E_ROBOT_CHILD.CH_DRILL).transform.position.x, 32f, -1f);
            transform.GetChild((int)E_ROBOT_CHILD.CH_DRILL).transform.position = transform.GetChild((int)E_ROBOT_CHILD.CH_BODY).transform.position + Offsets[2];
            transform.GetChild((int)E_ROBOT_CHILD.CH_BODY).GetComponent<Rigidbody2D>().velocity = new Vector2(transform.GetChild((int)E_ROBOT_CHILD.CH_BODY).GetComponent<Rigidbody2D>().velocity.x, 0);
        }
    }



    // Start is called before the first frame update

    private void Init()
    {
        //This function places the robot to the spawnpoint, facing right
        if (transform.childCount <= 0)
        {
            GameObject R = Instantiate(robotRight, new Vector3(0, 32, -1), Quaternion.identity);
            GameObject D = Instantiate(drillRight, new Vector3(0, 32, -1) + new Vector3(drillRightOffset.x, drillRightOffset.y, 0f), Quaternion.identity);
            R.transform.parent = gameObject.transform;
            D.transform.parent = gameObject.transform;
            moveDirection = (int)E_ROBOT_MOVEMENT_DIR.MOVE_RIGHT;
        }
    }

    void Start()
    {
        //We spawn the robot
        Init();
        //We also initatite a Coroutine to check if the robot is too deep according to its coreLevel
        StartCoroutine(DamageCheck());
    }

    void Respawn()
    {
        //We destroy the robot object and spawn it to the spawnpoint with max health
        DestroyChildren();
        Init();
        Health = 100;

        //We also take a fee for reconstructing the dead robot, and clear its inventory since it's gone.
        GetComponent<Inventory>().Money = (int)((float)GetComponent<Inventory>().Money * (1f - GameInfoHolder.Get().MoneyTakeOnDeathPercentage));
        GetComponent<Inventory>().items.Clear();
    }
    IEnumerator DamageCheck()
    {
        GameInfoHolder gih = GameInfoHolder.Get();
        while (true)
        {
            //The maximum depth the robot can handle
            int maxDepth = (int)gih.BlockDistance * gih.CoreDepth[coreLevel];

            //If the robot is too deep
            if (transform.GetChild((int)E_ROBOT_CHILD.CH_BODY).transform.position.y < -maxDepth)
            {
                //For each block lower than the maxDepth the damage increases by 1.
                float Delta = -(float)maxDepth - transform.GetChild((int)E_ROBOT_CHILD.CH_BODY).transform.position.y;
                int iDelta = Mathf.CeilToInt(Delta / 32f);
                Health -= iDelta;

                //If the robot dies, we respawn
                if (Health <= 0) 
                    Respawn();

                //We update the UI to show the damage
                UIManager.Get().UpdateAll();
            }

            //Every second, we do this check
            yield return new WaitForSeconds(1f);
        }
    }






    // Update is called once per frame
    void Update()
    {
        RotateRobot();
        MoveRobot();
    }
}
