using UnityEngine;
using System.Collections;

public class SceneFadeIn : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float fadeDuration = 2.0f; // Duration of the fade-in effect

    private void Start()
    {
        canvasGroup.alpha = 0.0f; // Start with the canvas fully transparent
        StartCoroutine(FadeInCanvasGroup(canvasGroup));
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

        group.alpha = 1.0f; // Ensure the canvas is fully visible
    }
}
