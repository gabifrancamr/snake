using UnityEngine;
using UnityEngine.SceneManagement; // Necessário para mudar de cena

public class MenuController : MonoBehaviour
{
    // Nome exato da sua cena de jogo que está na pasta Scenes
    [SerializeField] private string gameSceneName = "SnakeGame";

    public void PlayGame()
    {
        // Carrega a cena principal
        SceneManager.LoadScene(gameSceneName);
    }

    public void QuitGame()
    {
        // Isso faz o botão parar o "Play" dentro do editor do Unity
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}