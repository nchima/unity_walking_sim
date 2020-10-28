using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    GameObject playerMain;
    GameObject playerAlt;

    bool playerHasFreeMovement = false;

    // Start is called before the first frame update
    void Start()
    {
        var players = FindObjectsOfType<Player>();

        foreach (var player in players)
        {

            if (player.gameObject.tag == "player-main")
            {
                playerMain = player.gameObject;
            }

            if (player.gameObject.tag == "player-ruins")
            {
                playerAlt = player.gameObject;
            }



        }

        // Deactivate none active player
        playerMain.GetComponentInChildren<Camera>().enabled = false;
        playerAlt.GetComponentInChildren<Camera>().enabled = true;

    }

    private void Update()
    {

        if (!playerHasFreeMovement)
        {
            // Disable player ability to walk any direction that is not straight
            // ahead
        }

        playerMain.transform.localPosition = playerAlt.transform.localPosition;



        //Debug.Log(playerAlt.transform.localPosition + "------" + playerMain.transform.localPosition);
        //playerAlt.transform.position = playerMain.transform.position;
        //playerAlt.transform.rotation = playerMain.transform.rotation;

    }

    public GameObject GetPlayerMain()
    {
        return playerMain;
    }

    public GameObject GetPlayerAlt()
    {
        return playerAlt;
    }

    public void SendToApocalypticWorld()
    {

        playerMain.GetComponentInChildren<Camera>().enabled = false;
        playerAlt.GetComponentInChildren<Camera>().enabled = true;
    }

    public void SendToNormalWorld()
    {

        playerAlt.GetComponentInChildren<Camera>().enabled = false;
        playerMain.GetComponentInChildren<Camera>().enabled = true;

    }

    public bool HasApple()
    {

        bool hasApple = false;

        var apple = playerMain.GetComponentsInChildren<Apple>();

        if (apple.Length > 0)
        {
            hasApple = true;
        }

        return hasApple;

    }

    public void ActivatePlayer()
    {
        playerHasFreeMovement = true;
    }
}
