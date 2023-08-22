using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CanvasManager : MonoBehaviour
{
    public CanvasGroup logoCanvasGroup;
    public CanvasGroup mainMenuCanvasGroup;

    public GameObject logoPanel;
    public GameObject mainMenuPanel;
    public float logoDuration = 3.0f; // Time to display the logo panel
    public float fadeDuration = 2.0f; // Duration of the fade-in effect

    private void Start()
    {
        // Start with the logo panel active and fully transparent
        logoPanel.SetActive(true);
        logoCanvasGroup.alpha = 0.0f;

        mainMenuPanel.SetActive(false);
        mainMenuCanvasGroup.alpha = 0.0f;

        // Start the coroutine for the fade-in effect
        StartCoroutine(ShowLogoThenMainMenu());
    }

    private IEnumerator ShowLogoThenMainMenu()
    {
        float elapsedTime = 0f;
        float startAlpha = 0.0f;
        float targetAlpha = 1.0f;

        while (elapsedTime < fadeDuration)
        {
            float normalizedTime = elapsedTime / fadeDuration;
            logoCanvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, normalizedTime);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Once logo fade-in is done, wait for logoDuration seconds before fading out
        yield return new WaitForSeconds(logoDuration);

        // Start the fade-out effect for the logo
        StartCoroutine(FadeOutCanvasGroup(logoCanvasGroup, ShowMainMenu));
    }

    private void ShowMainMenu()
    {
        // Disable the logo panel
        logoPanel.SetActive(false);

        // Enable the main menu panel and start the fade-in effect for it
        mainMenuPanel.SetActive(true);
        StartCoroutine(FadeInCanvasGroup(mainMenuCanvasGroup));
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

    private IEnumerator FadeOutCanvasGroup(CanvasGroup group, System.Action onComplete = null)
    {
        float elapsedTime = 0.0f;
        float startAlpha = group.alpha;

        while (elapsedTime < fadeDuration)
        {
            group.alpha = Mathf.Lerp(startAlpha, 0.0f, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        group.alpha = 0.0f;

        onComplete?.Invoke();
    }
}
