using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class BallMovement : MonoBehaviour
{
    private int _moveDirectionX = 1;
    private int _moveDirectionZ = 1;
    private float _startZ;
    private Rigidbody _rb;



    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        Vector3 mov = Vector3.zero;
        mov.x += _moveDirectionX;
        //_startZ = Random.Range(-0.8f, 0.8f);
        mov.z += _startZ * _moveDirectionZ ;
        _rb.AddForce(mov.normalized * 1000);
    }

    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.name)
        {
            case "PaddleLeft" or "PaddleRight":
                _moveDirectionX *= -1;
                var transform1 = transform;
                _startZ = (transform1.position.z - other.transform.position.z) * 6f;
                Vector3 mov = Vector3.zero;
                mov.x += _moveDirectionX;
                mov.z += _startZ * _moveDirectionZ ;
                _rb.AddForce(mov.normalized * 500);
                return;
            case "WallRight":
                PartyManager.instance.HandleLeftScore();
                break;
            case "WallLeft":
                PartyManager.instance.HandleRightScore();
                break;
        }
    }

    /*private void FixedUpdate()
    {
        Vector3 mov = Vector3.zero;
        mov.x += _moveDirectionX;
        mov.z += _startZ * _moveDirectionZ ;
        transform.position += mov.normalized * _speed;
        
    }*/
}
