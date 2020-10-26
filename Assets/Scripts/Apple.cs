using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{

    PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

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
        if (Input.GetMouseButtonDown(0))
        {
            GameObject playerAlt = playerController.GetPlayerAlt();
            if (Vector3.Distance(playerAlt.transform.position, transform.position) < 1f)
            { return; }

            transform.parent = playerAlt.transform;
            transform.localPosition = new Vector3(0, 0, 2);

            playerController.SendToApocalypticWorld();

        }

        else if (Input.GetMouseButtonDown(1))
        {
            if (!playerController.HasApple())
            { return; }

            GameObject playerMain = playerController.GetPlayerMain();
            GameObject playerAlt = playerController.GetPlayerAlt();

            Vector3 applePosition = playerMain.transform.localPosition;
            applePosition.z += 2f;
            transform.parent = playerMain.transform.parent;
            transform.localPosition = applePosition;

            playerController.SendToNormalWorld();

        }
    }
}
