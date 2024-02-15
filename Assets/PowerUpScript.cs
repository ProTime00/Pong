using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PowerUpScript : MonoBehaviour
{
    private bool _startAnimDestroy;
    public GameObject[] targets;
    public int targetPaddle;
    public static PowerUpScript PowerUpScriptInstance;

    private void Awake()
    {
        PowerUpScriptInstance = this;
    }

    private void FixedUpdate()
    {
        if (_startAnimDestroy)
        {
            if (targetPaddle != 0)
            {
                transform.Translate(Vector3.forward);
                transform.LookAt(targets[targetPaddle - 1].transform);
            }
            return;
        }
        transform.Rotate(Vector3.up, 1, Space.Self);
        transform.Rotate(Vector3.left, 1, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Ball")
        {
            _startAnimDestroy = true;
            return;
        }
        if (other.gameObject.name is "PaddleLeft" or "PaddleRight")
        {
            gameObject.SetActive(false);
            _startAnimDestroy = false;
            targetPaddle = 0;
        }
    }
}
