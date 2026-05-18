using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIManager uiManager;

    public SnakeController snakeController;
    public FoodSpawner foodSpawner;

    int score = 0;
    int highScore = 0;

    bool gameOver = false;

    public bool IsGameOver()
    {
        return gameOver;
    }

    void Start()
    {
        uiManager.UpdateScore(0);
        uiManager.UpdateHighScore(highScore);
        uiManager.HideGameOver();
    }

    public void AddScore()
    {
        score++;

        uiManager.UpdateScore(score);
    }

    public void GameOver()
    {
        gameOver = true;

        uiManager.ShowGameOver();

        if (score > highScore)
        {
            highScore = score;
        }

        uiManager.UpdateHighScore(highScore);
    }

    public void RestartGame()
    {
        gameOver = false;

        uiManager.HideGameOver();

        score = 0;

        uiManager.UpdateScore(0);

        snakeController.ResetSnake();

        foodSpawner.ClearFoods();
        foodSpawner.SpawnInitialFood();
    }
}