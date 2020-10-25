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

    private void OnTriggerEnter(Collider other)
    {
        GameObject playerAlt = playerController.GetPlayerAlt();

        Debug.Log("Collided with apple");

        if (other.tag == "player-main")
        {
            transform.parent = playerAlt.transform;
            transform.localPosition = new Vector3(0, 0, 2);

            playerController.SendToApocalypticWorld();
        }
    }
}
