using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PaddleMovement : MonoBehaviour
{
    private Pong _actions;
    private InputAction _pAction;
    public bool isRightPaddle;

    private void Awake()
    {
        _actions = new Pong();
    }

    private void OnEnable()
    {
        _pAction = isRightPaddle ? _actions.Player.RightPaddleBind : _actions.Player.LeftPaddleBind;
        _pAction.Enable();
        
    }

    private void OnDisable()
    {
        _pAction.Disable();
    }

    private void FixedUpdate()
    {
        Vector3 movDir = Vector3.zero;
        float mov = _pAction.ReadValue<float>();
        movDir.z += mov;
        transform.position += movDir;
        if (transform.position.z > 16.5 + 25)
        {
            var transform1 = transform;
            var vector3 = transform1.position;
            vector3.z = (float)16.5 + 25;
            transform1.position = vector3;
        }
        else if (transform.position.z < -16.5 + 25)
        {
            var transform1 = transform;
            var vector3 = transform1.position;
            vector3.z = (float)-16.5 + 25;
            transform1.position = vector3;
        }
    }
}