using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Texts")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    [Header("GameOver Panel")]
    // Substituímos os elementos soltos pelo painel PAI que engloba tudo
    public GameObject gameOverPanel;

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
        // Ativa o painel inteiro (o texto, o restart e o quit aparecem juntos)
        gameOverPanel.SetActive(true);
    }

    public void HideGameOver()
    {
        // Desativa o painel inteiro (tudo o que está dentro dele some da tela)
        gameOverPanel.SetActive(false);
    }
}