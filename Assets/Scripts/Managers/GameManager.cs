using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Global Settings")]
    public float cellSize = 0.3f;
    public float initialSpeed = 5.0f;
    [HideInInspector] public float currentSpeed;

    [Header("References")]
    public UIManager uiManager;
    public SnakeController snakeController;
    public FoodSpawner foodSpawner;
    public WallGenerator wallGenerator;

    private int score = 0;
    private int highScore = 0;
    private bool gameOver = false;

    public bool IsGameOver() => gameOver;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        currentSpeed = initialSpeed;
        wallGenerator.CreateWalls(cellSize);
        foodSpawner.SpawnInitialFood(cellSize);

        uiManager.UpdateScore(0);
        uiManager.UpdateHighScore(highScore);
        uiManager.HideGameOver();
    }

    private void Update()
    {
        if (gameOver && Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }

    public void OnFoodEaten(GameObject foodObject)
    {
        foodSpawner.RemoveFood(foodObject);
        score++;
        currentSpeed += 0.5f;

        uiManager.UpdateScore(score);
        foodSpawner.SpawnFood(cellSize);

        AudioManager.Instance.PlayFoodSound();
    }

    public void GameOver()
    {
        gameOver = true;
        uiManager.ShowGameOver();

        if (score > highScore) highScore = score;
        uiManager.UpdateHighScore(highScore);

        AudioManager.Instance.PlayGameOverSound();
    }

    public void RestartGame()
    {
        gameOver = false;
        score = 0;
        currentSpeed = initialSpeed;

        uiManager.HideGameOver();
        uiManager.UpdateScore(0);

        snakeController.ResetSnake();
        foodSpawner.ClearFoods();
        foodSpawner.SpawnInitialFood(cellSize);
    }
}