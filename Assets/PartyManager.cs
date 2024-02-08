using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PartyManager : MonoBehaviour
{
    public int scoreLeft;
    public int scoreRight;
    public GameObject DESTROYED;
    public GameObject BallPrefab;
    private int wait = 150;
    private bool scoredRight;
    private bool scoredLeft;
    private BallMovement ballMovement;
    
    

    public static PartyManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        ballMovement = BallPrefab.GetComponent<BallMovement>();
    }

    private void FixedUpdate()
    {
        if (scoredLeft)
        {
            wait--;
            if (wait == 0)
            {
                wait = 150;
                scoredLeft = false;
                ballMovement._moveDirectionX = 1;
                DESTROYED = Instantiate(BallPrefab);
            }
        }

        if (scoredRight)
        {
            wait--;
            if (wait == 0)
            {
                wait = 150;
                scoredRight = false;
                ballMovement._moveDirectionX = -1;
                DESTROYED = Instantiate(BallPrefab);
            }
        }
    }

    public void HandleLeftScore()
    {
        scoreLeft += 1;
        if (scoreLeft >= 11)
        {
            HandleWinLeft();
            return;
        }
        scoredLeft = true;
        Destroy(DESTROYED);
    }

    private void HandleWinLeft()
    {
        Debug.Log("Left win!");
    }

    public void HandleRightScore()
    {
        scoreRight += 1;
        if (scoreRight >= 11)
        {
            HandleWinRight();
            return;
        }
        scoredRight = true;
        Destroy(DESTROYED);
    }

    private void HandleWinRight()
    {
        Debug.Log("Right win!");
    }
}
