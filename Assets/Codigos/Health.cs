using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public LevelInteractionManager interactionManager; // Reference to the LevelInteractionManager script

    private bool gameOver = false; // Flag to track if game over has occurred

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateUI();

        // Make sure to assign the LevelInteractionManager reference in the Inspector
        if (interactionManager == null)
        {
            interactionManager = GameObject.FindObjectOfType<LevelInteractionManager>();
        }
    }

    private void UpdateUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].sprite = (i < currentHealth) ? fullHeart : emptyHeart;
        }
    }

    public void ReduceHealth(int amount)
    {
        if (!gameOver && currentHealth > 0)
        {
            currentHealth -= amount;
            UpdateUI();

            if (currentHealth <= 0)
            {
                // Show the Game Over panel using the reference to LevelInteractionManager
                interactionManager.ShowGameOverPanel();
                gameOver = true; // Set game over flag
            }
        }
    }

    public bool IsGameOver()
    {
        return gameOver;
    }
}
