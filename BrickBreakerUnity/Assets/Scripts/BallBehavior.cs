using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    public float Speed = 5.0f ;
    Vector2 direction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         direction.x = Random.value > 0.5f ? 1 : -1;
         direction.y = Random.value > 0.5f ? 1 : -1;
    }

    // Update is called once per frame
    void Update()
    {
         Vector3 movement = direction * Speed * Time.deltaTime;
        transform.Translate(movement);
    }
}
