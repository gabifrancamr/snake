using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    public Transform bodyPrefab;
    private List<Transform> body = new List<Transform>();

    private Vector2 direction = Vector2.up;
    private float nextMoveTime = 0;

    void Update()
    {
        if (GameManager.Instance.IsGameOver()) return;

        ChangeDirection();
        Move();
    }

    void ChangeDirection()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (input.y == 1 && direction != Vector2.down)
        {
            // SÓ TOCA SE A COBRA NÃO ESTIVER INDO PARA CIMA AINDA
            if (direction != Vector2.up)
            {
                direction = Vector2.up;
                AudioManager.Instance.PlayMoveSound();
            }
        }
        else if (input.y == -1 && direction != Vector2.up)
        {
            if (direction != Vector2.down)
            {
                direction = Vector2.down;
                AudioManager.Instance.PlayMoveSound();
            }
        }
        else if (input.x == -1 && direction != Vector2.right)
        {
            if (direction != Vector2.left)
            {
                direction = Vector2.left;
                AudioManager.Instance.PlayMoveSound();
            }
        }
        else if (input.x == 1 && direction != Vector2.left)
        {
            if (direction != Vector2.right)
            {
                direction = Vector2.right;
                AudioManager.Instance.PlayMoveSound();
            }
        }
    }

    void Move()
    {
        if (Time.time > nextMoveTime)
        {
            float cellSize = GameManager.Instance.cellSize;
            float speed = GameManager.Instance.currentSpeed;

            // Move o corpo de trás para frente
            for (int i = body.Count - 1; i > 0; i--)
            {
                body[i].position = body[i - 1].position;
            }

            if (body.Count > 0)
            {
                body[0].position = (Vector2)transform.position;
            }

            transform.position += (Vector3)direction * cellSize;
            nextMoveTime = Time.time + 1f / speed;
        }
    }

    public void GrowBody()
    {
        Vector2 position = transform.position;
        if (body.Count != 0)
        {
            position = body[body.Count - 1].position;
        }

        body.Add(Instantiate(bodyPrefab, position, Quaternion.identity).transform);
    }

    // A Mágica da Unity: Substitui todas as checagens manuais de listas!
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Food"))
        {
            GrowBody();
            GameManager.Instance.OnFoodEaten(collision.gameObject);
        }
        else if (collision.CompareTag("Wall"))
        {
            GameManager.Instance.GameOver();
        }
        else if (collision.CompareTag("Body"))
        {
            // SÓ DÁ GAME OVER SE A COBRA JÁ TIVER UM CORPO CONSIDERÁVEL
            // Se ela acabou de começar ou só tem 1 ou 2 gomos, ignora a colisão imediata
            if (body.Count > 2)
            {
                GameManager.Instance.GameOver();
            }
        }
    }

    public void ResetSnake()
    {
        for (int i = 0; i < body.Count; ++i)
        {
            Destroy(body[i].gameObject);
        }
        body.Clear();

        transform.position = Vector3.zero;
        direction = Vector2.up;
        nextMoveTime = 0;
    }
}