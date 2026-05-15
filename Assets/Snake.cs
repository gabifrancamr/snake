using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Snake : MonoBehaviour
{
    public Transform foodPrefab;
    public Transform bodyPrefab;
    public Transform wallPrefab;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI gameOverText;

    List<Transform> food = new List<Transform>();
    List<Transform> body = new List<Transform>();
    List<Transform> wall = new List<Transform>();

    Vector2 direction = Vector3.up;
    public float cellSize = 0.3f;
    public float speed = 10.0f; //Cells per second

    public int initialFoods = 1;

    float moveTime = 0;
    Vector2 snakeIndex;

    bool gameOver = false;

    int score = 0;
    int highScore = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CreateWalls();
        for (int i = 0; i < initialFoods; i++) SpawnFood();

        scoreText.text = "SCORE: 0";
        highScoreText.text = "HIGH SCORE: 0";
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.R)) Restart();
            return;
        }

        ChangeDirection();

        Move();

        EatFood();

        CheckWallCollioson();
        CheckBodyCollision();
    }

    void ChangeDirection()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (input.y == -1)
        {
            direction = Vector2.down;
        }
        else if (input.y == 1)
        {
            direction = Vector2.up;
        }
        else if (input.x == -1)
        {
            direction = Vector2.left;
        }
        else if (input.x == 1)
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
        for (int i = 0; i < food.Count; ++i)
        {
            Vector2 foodIndex = food[i].position / cellSize;
            if (Mathf.Abs(foodIndex.x - snakeIndex.x) < 0.00001f && Mathf.Abs(foodIndex.y - snakeIndex.y) < 0.00001f)
            {
                Destroy(food[i].gameObject);
                food.RemoveAt(i);
                GrowBody();

                score++;
                scoreText.text = "SCORE: " + score;

                SpawnFood();

                break;
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

    void CreateWalls()
    {
        //baseado no tamanho da tela
        int cellX = -24;
        int cellY = 11;
        int height = 25;

        float horizontal = cellX * cellSize;
        float vertical = cellY * cellSize;

        for (int i = 0; i < (int)Mathf.Abs((horizontal * 2) / cellSize) + 1; ++i)
        {
            Vector2 top = new Vector3(horizontal + cellSize * i, vertical);
            Vector2 bottom = new Vector3(horizontal + cellSize * i, vertical - height * cellSize);
            wall.Add(Instantiate(wallPrefab, top, Quaternion.identity).transform);
            wall.Add(Instantiate(wallPrefab, bottom, Quaternion.identity).transform);
        }

        for (int i = 0; i < height; ++i)
        {
            Vector2 right = new Vector3(horizontal, vertical - cellSize * i);
            Vector2 left = new Vector3(-horizontal, vertical - cellSize * i);
            wall.Add(Instantiate(wallPrefab, right, Quaternion.identity).transform);
            wall.Add(Instantiate(wallPrefab, left, Quaternion.identity).transform);
        }
    }

    void CheckWallCollioson()
    {
        for (int i = 0; i < wall.Count; ++i)
        {
            Vector2 index = wall[i].position / cellSize;
            if (Mathf.Abs(index.x - snakeIndex.x) < 0.00001f && Mathf.Abs(index.y - snakeIndex.y) < 0.00001f)
            {
                GameOver();
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
                GameOver();
                break;
            }
        }
    }

    void GameOver()
    {
        gameOver = true;

        gameOverText.enabled = true;

        if (score > highScore)
        {
            highScore = score;
        }

        highScoreText.text = "HIGH SCORE: " + highScore;
    }

    void Restart()
    {
        gameOver = false;

        gameOverText.enabled = false;

        score = 0;
        scoreText.text = "SCORE: 0";

        // Remove corpo
        for (int i = 0; i < body.Count; ++i)
        {
            Destroy(body[i].gameObject);
        }
        body.Clear();

        // Remove comidas
        for (int i = 0; i < food.Count; ++i)
        {
            Destroy(food[i].gameObject);
        }
        food.Clear();

        // Reset posição e direção
        transform.position = Vector3.zero;

        direction = Vector2.up;

        for (int i = 0; i < initialFoods; i++)
        {
            SpawnFood();
        }
    }
}