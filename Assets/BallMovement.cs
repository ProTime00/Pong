using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class BallMovement : MonoBehaviour
{
    [FormerlySerializedAs("_moveDirectionX")] public int moveDirectionX = 1;
    private float _startZ;
    private Rigidbody _rb;

    private void Awake()
    {
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

    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.name)
        {
            case "PaddleLeft" or "PaddleRight":
                moveDirectionX *= -1;
                var transform1 = transform;
                _startZ = (transform1.position.z - other.transform.position.z) * 6f;
                var mov = Vector3.zero;
                mov.x = moveDirectionX;
                mov.z = _startZ;
                _rb.AddForce(mov.normalized * 500);
                return;
            case "WallRight":
                PartyManager.Instance.HandleLeftScore();
                break;
            case "WallLeft":
                PartyManager.Instance.HandleRightScore();
                break;
        }
    }
}
