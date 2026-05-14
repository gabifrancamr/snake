using UnityEngine;

public class Snake : MonoBehaviour
{
    Vector2 direction = Vector3.up;
    public float cellSize = 0.3f;
    public float speed = 10.0f; //Cells per second

    float moveTime = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ChangeDirection();

        Move();
    }

    void ChangeDirection()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if(input.y == -1)
        {
            direction = Vector2.down;
        } else if(input.y == 1)
        {
            direction = Vector2.up;
        } else if(input.x == -1)
        {
            direction = Vector2.left;
        } else if(input.x == 1)
        {
            direction = Vector2.right;
        }
    }

    void Move()
    {
        if(Time.time > moveTime)
        {
            transform.position += (Vector3)direction * cellSize;
            moveTime = Time.time + 1 / speed;
        }
    }
}
