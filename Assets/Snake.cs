using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public Transform foodPrefab;
    public Transform bodyPrefab;

    List<Transform> food = new List<Transform>();
    List<Transform> body = new List<Transform>();

    Vector2 direction = Vector3.up;
    public float cellSize = 0.3f;
    public float speed = 10.0f; //Cells per second

    public int initialFoods = 10;

    float moveTime = 0;
    Vector2 snakeIndex;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < initialFoods; i++) SpawnFood();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeDirection();

        Move();

        EatFood();
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
            for(int i = body.Count - 1; i > 0; i--)
            {
                body[i].position = body[i - 1].position;
            }

            if (body.Count > 0)
                body[0].position = (Vector2)transform.position; //passa posição da cabeça para primeiro elemento da lista

            transform.position += (Vector3)direction * cellSize;
            moveTime = Time.time + 1 / speed;
            snakeIndex = transform.position / cellSize;
        }
    }

    void GrowBody()
    {
        Vector2 position = transform.position;

        if(body.Count != 0)
            position = body[body.Count - 1].position;
        body.Add(Instantiate(bodyPrefab, position, Quaternion.identity).transform);
    }

    void EatFood()
    {
        for (int i = 0; i < food.Count; ++i)
        {
            Vector2 foodIndex = food[i].position / cellSize;
            if (Mathf.Abs(foodIndex.x - snakeIndex.x) < 0.00001f && Mathf.Abs(foodIndex.y - snakeIndex.y) < 0.00001f)
            {
                Destroy(food[i].gameObject);
                food.Remove(food[i]);
                GrowBody();
            }
        }
    }

    void SpawnFood()
    {
        float x = Random.Range(-23, 23) * cellSize;
        float y = Random.Range(-13, 11) * cellSize;
        Vector2 randomPosition = new Vector2(x, y);
        food.Add(Instantiate(foodPrefab, randomPosition, Quaternion.identity).transform);
    }
}
