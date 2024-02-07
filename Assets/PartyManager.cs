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

    public static PartyManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void HandleLeftScore()
    {
        scoreLeft += 1;
        // win here
        Destroy(DESTROYED);
        DESTROYED = Instantiate(BallPrefab);
        
    }

    public void HandleRightScore()
    {
        scoreRight += 1;
        // win here
        Destroy(DESTROYED);
        
        DESTROYED = Instantiate(BallPrefab);
    }
}
