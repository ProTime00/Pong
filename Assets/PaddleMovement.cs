using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleMovement : MonoBehaviour
{
    private Pong _actions;
    private InputAction _pAction;
    public bool isRightPaddle;
    public float speedRight = 1;
    public float speedLeft = 1;
    public static PaddleMovement PaddleMovementInstance;
    

    private void Awake()
    {
        PaddleMovementInstance = this;
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
        var movDir = Vector3.zero;
        var mov = _pAction.ReadValue<float>();
        movDir.z += mov;
        if (isRightPaddle)
        {
            transform.position += movDir * speedRight;
        }
        else
        {
            transform.position += movDir * speedLeft;
        }
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
