using UnityEngine;
using System.Collections;

public class SceneFadeOut : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float fadeDuration = 2.0f; // Duration of the fade-out effect

    private void Start()
    {
        canvasGroup.alpha = 1.0f; // Start with the canvas fully visible (black)
        StartCoroutine(FadeOutCanvasGroup(canvasGroup));
    }

    private IEnumerator FadeOutCanvasGroup(CanvasGroup group)
    {
        float elapsedTime = 0.0f;
        float startAlpha = group.alpha;

        while (elapsedTime < fadeDuration)
        {
            group.alpha = Mathf.Lerp(startAlpha, 0.0f, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        group.alpha = 0.0f; // Ensure the canvas is fully transparent
        gameObject.SetActive(false); // Disable the canvas after the fade-out
    }
}
