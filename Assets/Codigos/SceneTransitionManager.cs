using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public CanvasGroup logoCanvasGroup;
    public CanvasGroup mainMenuCanvasGroup;

    public GameObject logoPanel;
    public GameObject mainMenuPanel;
    public float logoDuration = 3.0f; // Time to display the logo panel
    public float fadeDuration = 2.0f; // Duration of the fade-in/out effect

    private void Start()
    {
        logoPanel.SetActive(true);
        logoCanvasGroup.alpha = 0.0f;

        mainMenuPanel.SetActive(false);
        mainMenuCanvasGroup.alpha = 0.0f;

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

        yield return new WaitForSeconds(logoDuration);

        StartCoroutine(FadeOutCanvasGroup(logoCanvasGroup, ShowMainMenu));
    }

    private void ShowMainMenu()
    {
        logoPanel.SetActive(false);
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

    public void LoadLevel1()
    {
        StartCoroutine(FadeOutMainMenuAndLoadLevel());
    }

    private IEnumerator FadeOutMainMenuAndLoadLevel()
    {
        StartCoroutine(FadeOutCanvasGroup(mainMenuCanvasGroup));
        yield return new WaitForSeconds(fadeDuration);
        SceneManager.LoadScene("Nivel_1");
    }
}
