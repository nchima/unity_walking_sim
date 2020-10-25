using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    GameObject playerMain;
    GameObject playerAlt;

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
        playerMain.GetComponentInChildren<Camera>().enabled = true;
        playerAlt.GetComponentInChildren<Camera>().enabled = false;

    }

    private void Update()
    {
        playerAlt.transform.localPosition = playerMain.transform.localPosition;

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
}
