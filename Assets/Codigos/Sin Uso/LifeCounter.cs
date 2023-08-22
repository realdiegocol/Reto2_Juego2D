using UnityEngine;
using TMPro;

public class LifeCounter : MonoBehaviour
{
    public int totalLives = 3;
    public TextMeshProUGUI livesText;

    private int currentLives;

    private void Start()
    {
        currentLives = totalLives;
        UpdateUI();
    }

    public void ReduceLife()
    {
        if (currentLives > 0)
        {
            currentLives--;
            UpdateUI(); // Handle game over here
        }
        else
        {
            Debug.Log("No more lives remaining.");
        }
    }

    private void UpdateUI()
    {
        livesText.text = currentLives.ToString();
    }
}