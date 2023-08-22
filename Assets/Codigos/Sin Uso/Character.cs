/*
Program to Show Remaining Lives of a Character in a 2D Game

This program provides a function to calculate and display the remaining lives of a character in a 2D game in Unity.

*/

using UnityEngine;
using System;

public class Character : MonoBehaviour
{
    private int maxLives = 3;  // Maximum number of lives for the character
    private int currentLives;  // Current number of lives for the character

    // Start is called before the first frame update
    void Start()
    {
        currentLives = maxLives;  // Initialize current lives to maximum lives
    }

    // Function to show the remaining lives of the character
    public void ShowRemainingLives()
    {
        try
        {
            Debug.Log("Remaining Lives: " + currentLives);
        }
        catch (Exception e)
        {
            Debug.LogError("An error occurred: " + e.Message);
        }
    }

    // Function to decrease the character's lives
    public void DecreaseLives()
    {
        try
        {
            if (currentLives > 0)
            {
                currentLives--;
                Debug.Log("Lives decreased. Remaining Lives: " + currentLives);
            }
            else
            {
                Debug.Log("No more lives remaining.");
            }
        }
        catch (Exception e)
        {
            Debug.LogError("An error occurred: " + e.Message);
        }
    }

    // Example usage of the program
    void ExampleUsage()
    {
        ShowRemainingLives();  // Output: Remaining Lives: 3

        DecreaseLives();  // Output: Lives decreased. Remaining Lives: 2

        DecreaseLives();  // Output: Lives decreased. Remaining Lives: 1

        DecreaseLives();  // Output: Lives decreased. Remaining Lives: 0

        DecreaseLives();  // Output: No more lives remaining.
    }
}