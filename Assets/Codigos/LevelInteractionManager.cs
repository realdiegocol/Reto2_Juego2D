using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public enum GameState
{
    Playing,
    GameOver,
    Victory
}

public class LevelInteractionManager : MonoBehaviour
{
    public GameState CurrentState { get; private set; } = GameState.Playing;

    public CanvasGroup gameOverCanvasGroup;
    public CanvasGroup victoryCanvasGroup;

    public float fadeDuration = 1.0f; // Adjust as needed

    private void Start()
    {
        // Initialize and set up your UI elements as needed...
    }

    public void ShowGameOverPanel()
    {
        if (CurrentState == GameState.Playing)
        {
            CurrentState = GameState.GameOver;
            gameOverCanvasGroup.gameObject.SetActive(true);
            StartCoroutine(FadeInCanvasGroup(gameOverCanvasGroup));
        }
    }

    public void ShowVictoryPanel()
    {
        if (CurrentState == GameState.Playing)
        {
            CurrentState = GameState.Victory;
            victoryCanvasGroup.gameObject.SetActive(true);
            StartCoroutine(FadeInCanvasGroup(victoryCanvasGroup));
        }
    }

    private IEnumerator FadeInCanvasGroup(CanvasGroup group)
    {
        float elapsedTime = 0.0f;
        float startAlpha = group.alpha;

        while (elapsedTime < fadeDuration)
        {
            group.alpha = Mathf.Lerp(startAlpha, 1.0f, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        group.alpha = 1.0f;
    }

    // Other methods...
}
