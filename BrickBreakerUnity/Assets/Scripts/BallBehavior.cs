using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    [SerializeField] private float _launchForce = 3.0f;
    [SerializeField] private float _paddleInfluence = 0.3f;
    [SerializeField] private float _speedMultiplier = 1.1f;
    [SerializeField] private AudioClip _wallClip;
    [SerializeField] private AudioClip _paddleClip;
    private AudioSource _source;
    private Rigidbody2D _rb;

    private void Start()
    {
        _source = GetComponent<AudioSource>();
        _rb = GetComponent<Rigidbody2D>();

        Vector2 direction = Random.insideUnitCircle;

        if (Mathf.Abs(direction.y) < 0.25f)
            direction.y += 0.5f * Mathf.Sign(direction.y);

        _rb.AddForce(direction.normalized * _launchForce, ForceMode2D.Impulse);
    }
    private void Update()
{
    _rb.simulated = GameBehavior.Instance.GameMode == Utilities.GameState.Play;
}

     private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Paddle"))
        {
            // This will execute when the paddle IS moving
            if (!Mathf.Approximately(other.rigidbody.linearVelocity.x, 0.0f))
            {
                // Weighted sum and one-minus
                Vector2 direction = _rb.linearVelocity * (1.0f - _paddleInfluence)
                                    + other.rigidbody.linearVelocity * _paddleInfluence;

                // Magnitude is the length of a vector, and we use it to maintain the same speed.
                // Normalization allows the length of the direction to always be 1.
                _rb.linearVelocity = _rb.linearVelocity.magnitude * direction.normalized;
            }
            
            _rb.linearVelocity *= _speedMultiplier;
            _source.PlayOneShot(_paddleClip);

        }
        else
         {
          _source.PlayOneShot(_wallClip);
         }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Ball fell out of bounds
        GameBehavior.Instance.Invoke(nameof(GameBehavior.Instance.ServeBall), 2f);
        Destroy(gameObject);
    }
}