using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject ball;
    private Transform _transform;
    private Quaternion _rota;

    private void Awake()
    {
        _transform = ball.transform;
        _rota = new Quaternion(0, 0, 0, 1);
    }

    private void FixedUpdate()
    {
        _rota.x = _transform.position.x / 100f;
        transform.rotation = _rota;
    }
}
