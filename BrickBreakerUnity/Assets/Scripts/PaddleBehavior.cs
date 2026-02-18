using UnityEngine;

public class PaddleBehavior : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private KeyCode _leftKey = KeyCode.A;
    [SerializeField] private KeyCode _rightKey = KeyCode.D;

    private Rigidbody2D _rb;
    private float _direction;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _direction = 0.0f;

        if (Input.GetKey(_leftKey)) { _direction -= 1.0f;}
        if (Input.GetKey(_rightKey)) { _direction += 1.0f;}
    }

    private void FixedUpdate()
    {
        _rb.linearVelocityX = _direction * _speed;
    }
}