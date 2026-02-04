using UnityEngine;
using UnityEngine.UIElements;

public class PaddleBehavior : MonoBehaviour
{
    public float Speed = 5.0f;
    public KeyCode LeftDirection = KeyCode.A;
    public KeyCode RightDirection = KeyCode.D;
    public float LeftWallLimit = -9.11f ;
    public float RighttWallLimit = 9.11f ;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float movement = 0.0f;

        if (Input.GetKey(LeftDirection))
        {
            movement -= Speed;
        }

        if (Input.GetKey(RightDirection))
        {
            movement += Speed;
        }
        transform.Translate(new Vector3(movement, 0.0f, 0.0f) * Time.deltaTime);

        Vector3 LimitPosition = transform.position ;
        if (LimitPosition.x > RighttWallLimit) 
        {
            LimitPosition.x = RighttWallLimit;
        } 

        if (LimitPosition.x < LeftWallLimit)
        {
            LimitPosition.x = LeftWallLimit;
        }

           transform.position = LimitPosition;



    }
}
