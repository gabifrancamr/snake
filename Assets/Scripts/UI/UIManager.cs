using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI gameOverText;

    public GameObject restartButton;

    public void UpdateScore(int score)
    {
        scoreText.text = "SCORE: " + score;
    }

    public void UpdateHighScore(int highScore)
    {
        highScoreText.text = "HIGH SCORE: " + highScore;
    }

    public void ShowGameOver()
    {
        gameOverText.enabled = true;
        restartButton.SetActive(true);
    }

    public void HideGameOver()
    {
        gameOverText.enabled = false;
        restartButton.SetActive(false);
    }
}
