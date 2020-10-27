using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{

    PlayerController playerController;
    public bool reachedEndGame = false;

    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            DropApple();
        }

        //var playerHoldingApple = playerAlt.GetComponentInChildren<Apple>();

    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    GameObject playerAlt = playerController.GetPlayerAlt();

    //    Debug.Log("Collided with apple");

    //    if (other.tag == "player-main")
    //    {
    //        transform.parent = playerAlt.transform;
    //        transform.localPosition = new Vector3(0, 0, 2);

    //        playerController.SendToApocalypticWorld();
    //    }
    //}

    private void OnMouseOver()
    {

        if (reachedEndGame == true)
        { return; }

        if (Input.GetMouseButtonDown(0))
        {
            GameObject playerAlt = playerController.GetPlayerAlt();
            GameObject playerMain = playerController.GetPlayerMain();

            //if (Vector3.Distance(playerAlt.transform.position, transform.position) > 1f)
            //{ return; }

            transform.parent = playerMain.transform;
            transform.localPosition = new Vector3(0, .5f, .5f);

            playerController.SendToNormalWorld();

        }
    }

    private void DropApple()
    {
        if (!playerController.HasApple())
        { return; }

        GameObject playerAlt = playerController.GetPlayerAlt();

        Vector3 applePosition = playerAlt.transform.localPosition;
        applePosition.y += .3f;
        applePosition.z += .5f;
        transform.parent = playerAlt.transform.parent;
        transform.localPosition = applePosition;

        playerController.SendToApocalypticWorld();

    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("Entered fountain");

    //}

    private void OnCollisonEnter(Collider other)
    {
        Debug.Log(other.tag);

        if (other.tag == "end-game")
        {
            reachedEndGame = true;
        }
    }
}
