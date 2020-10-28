using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fountain : MonoBehaviour
{
    Apple apple;
    PlayerController pc;

    private void Start()
    {
        apple = FindObjectOfType<Apple>();
        pc = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        FindAppleDistance();
    }

    private void FindAppleDistance()
    {
        var distanceToApple = Vector3.Distance(apple.gameObject.transform.position, transform.position);
        Debug.Log(apple.gameObject.transform.position + "---" + distanceToApple + "------" + transform.position);

        if (distanceToApple < 04f)
        {
            if (pc.HasApple())
            {
                apple.SetReachedEndGame();

            }
        }
    }
}
