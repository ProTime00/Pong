using System;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class BallMovement : MonoBehaviour
{
    public int moveDirectionX = 1;
    private float _startZ;
    private Rigidbody _rb;
    public float speed = 1000f;
    public static BallMovement BallMovementInstance;
    private bool _leftShooted = true;
    private Vector3 _startPos;

    private void Awake()
    {
        _startPos = transform.position;
        BallMovementInstance = this;
        _rb = GetComponent<Rigidbody>();
    }
    
    private void Start()
    {
        
        var mov = Vector3.zero;
        mov.x = moveDirectionX;
        _startZ = Random.Range(-0.8f, 0.8f);
        mov.z = _startZ;
        _rb.AddForce(mov.normalized * 1000);
    }

    public void StartBis()
    {
        transform.position = _startPos;
        var mov = Vector3.zero;
        mov.x = moveDirectionX;
        _startZ = Random.Range(-0.8f, 0.8f);
        mov.z = _startZ;
        _rb.AddForce(mov.normalized * 1000);
    }

    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.name)
        {
            case "PaddleLeft" or "PaddleRight":
                moveDirectionX *= -1;
                var transform1 = transform;
                _startZ = (transform1.position.z - other.transform.position.z) / 4f;
                var mov = Vector3.zero;
                if (_startZ < 0.1 && _startZ > -0.1)
                {
                    _startZ = 0;
                }
                
                _leftShooted = other.gameObject.name switch
                {
                    "PaddleLeft" => true,
                    "PaddleRight" => false,
                    _ => !_leftShooted
                };
                mov.x = moveDirectionX;
                mov.z = _startZ;
                speed *= 1.05f;
                Math.Clamp(speed, 500f, 8000f);
                _rb.AddForce(mov.normalized * speed);
                return;
            case "WallRight":
                speed = 1000f;
                ShakeHandler.ShakeHandlerInstance.Trauma = 0.7f;
                PartyManager.Instance.HandleLeftScore();
                break;
            case "WallLeft":
                speed = 1000f;
                ShakeHandler.ShakeHandlerInstance.Trauma = 0.7f;
                PartyManager.Instance.HandleRightScore();
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        switch (other.gameObject.name)
        {case "SlowEnnemyPowerUp":

            if (_leftShooted)
            {
                PaddleMovement.PaddleMovementInstance.speedRight *= 0.7f;
                PowerUpScript.PowerUpScriptInstance.targetPaddle = 1;
                return;
            }

            PaddleMovement.PaddleMovementInstance.speedLeft *= 0.7f;
            PowerUpScript.PowerUpScriptInstance.targetPaddle = 2;
            break;
            case "SpeedEnnemyPowerUp 1":
            if (_leftShooted)
            {
                PaddleMovement.PaddleMovementInstance.speedRight *= 1.5f;
                PowerUpScript.PowerUpScriptInstance.targetPaddle = 1;
                return;
            }

            PaddleMovement.PaddleMovementInstance.speedLeft *= 1.5f;
            PowerUpScript.PowerUpScriptInstance.targetPaddle = 2;
            break;
        }
    }
}

