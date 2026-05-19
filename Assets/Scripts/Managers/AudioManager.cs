using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [Header("Audio Sources")]
    [SerializeField] private AudioSource effectsSource;

    [Header("Audio Clips")]
    public AudioClip foodClip;
    public AudioClip moveClip;
    public AudioClip gameOverClip;

    void Awake()
    {
        // Garante que só exista um AudioManager no jogo
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void PlayFoodSound()
    {
        if (foodClip != null) effectsSource.PlayOneShot(foodClip);
    }

    public void PlayMoveSound()
    {
        if (moveClip != null) effectsSource.PlayOneShot(moveClip);
    }

    public void PlayGameOverSound()
    {
        if (gameOverClip != null) effectsSource.PlayOneShot(gameOverClip);
    }
}