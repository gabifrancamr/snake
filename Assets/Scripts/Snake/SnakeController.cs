using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    public WallGenerator wallGenerator;
    public UIManager uiManager;
    public FoodSpawner foodSpawner;
    public GameManager gameManager;

    public Transform bodyPrefab;

    List<Transform> body = new List<Transform>();

    Vector2 direction = Vector3.up;
    public float cellSize = 0.3f;
    public float speed = 5.0f; //Cells per second
    float initialSpeed;

    float moveTime = 0;
    Vector2 snakeIndex;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        wallGenerator.CreateWalls();

        foodSpawner.SpawnInitialFood();

        initialSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.IsGameOver())
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                gameManager.RestartGame();
            }

            return;
        }

        ChangeDirection();

        Move();

        EatFood();

        CheckWallCollision();
        CheckBodyCollision();
    }

    void ChangeDirection()
    {
        Vector2 input = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        );

        if (input.y == 1 && direction != Vector2.down)
        {
            direction = Vector2.up;
        }
        else if (input.y == -1 && direction != Vector2.up)
        {
            direction = Vector2.down;
        }
        else if (input.x == -1 && direction != Vector2.right)
        {
            direction = Vector2.left;
        }
        else if (input.x == 1 && direction != Vector2.left)
        {
            direction = Vector2.right;
        }
    }

    void Move()
    {
        if (Time.time > moveTime)
        {
            for (int i = body.Count - 1; i > 0; i--)
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

        if (body.Count != 0)
            position = body[body.Count - 1].position;
        body.Add(Instantiate(bodyPrefab, position, Quaternion.identity).transform);
    }

    void EatFood()
    {
        List<Transform> foods = foodSpawner.GetFoods();

        for (int i = 0; i < foods.Count; ++i)
        {
            Vector2 foodIndex = foods[i].position / cellSize;
            if (Mathf.Abs(foodIndex.x - snakeIndex.x) < 0.00001f && Mathf.Abs(foodIndex.y - snakeIndex.y) < 0.00001f)
            {
                foodSpawner.RemoveFood(i);
                GrowBody();

                speed += 0.5f;

                gameManager.AddScore();

                foodSpawner.SpawnFood();

                break;
            }
        }
    }

    void CheckWallCollision()
    {
        List<Transform> walls = wallGenerator.GetWalls();

        for (int i = 0; i < walls.Count; ++i)
        {
            Vector2 index = walls[i].position / cellSize;

            if (
                Mathf.Abs(index.x - snakeIndex.x) < 0.00001f &&
                Mathf.Abs(index.y - snakeIndex.y) < 0.00001f
            )
            {
                gameManager.GameOver();
                break;
            }
        }
    }

    void CheckBodyCollision()
    {
        if (body.Count < 3) return;

        for (int i = 0; i < body.Count; ++i)
        {
            Vector2 index = body[i].position / cellSize;
            if (Mathf.Abs(index.x - snakeIndex.x) < 0.00001f && Mathf.Abs(index.y - snakeIndex.y) < 0.00001f)
            {
                gameManager.GameOver();
                break;
            }
        }
    }

    public void ResetSnake()
    {
        speed = initialSpeed;

        for (int i = 0; i < body.Count; ++i)
        {
            Destroy(body[i].gameObject);
        }

        body.Clear();

        transform.position = Vector3.zero;

        direction = Vector2.up;
    }
}