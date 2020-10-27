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
            transform.localPosition = new Vector3(0, .3f, .5f);

            playerController.SendToNormalWorld();

        }
    }

    private void DropApple()
    {
        if (reachedEndGame == true)
        { return; }

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


    public void SetReachedEndGame()
    {
        GameObject playerMain = playerController.GetPlayerMain();
        Vector3 applePosition = playerMain.transform.localPosition;
        applePosition.y += .3f;
        applePosition.z += .5f;
        transform.parent = playerMain.transform.parent;
        transform.localPosition = applePosition;

        reachedEndGame = true;
    }
}
