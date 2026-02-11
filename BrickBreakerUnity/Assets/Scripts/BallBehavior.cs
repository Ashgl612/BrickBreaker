using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    public float LaunchForce = 3.0f;
    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        Vector2 direction = new Vector2(
            Random.value > 0.5f ? 1 : -1,
            Random.value > 0.5f ? 1 : -1
        ).normalized;

        _rb.AddForce(direction * LaunchForce, ForceMode2D.Impulse);
    }
}
