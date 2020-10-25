using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{

    PlayerController playerController;
    GameObject playerMain;
    GameObject playerAlt;

    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();

        playerMain = playerController.GetPlayerMain();
        playerAlt = playerController.GetPlayerAlt();
    }

    // Update is called once per frame
    void Update()
    {
        //var playerHoldingApple = playerAlt.GetComponentInChildren<Apple>();

    }

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("Collided with apple");

        if (other.tag == "player-main")
        {
            transform.parent = playerAlt.transform;
            transform.localPosition = new Vector3(0, 0, 2);

            playerController.SendToApocalypticWorld();
        }
    }
}
