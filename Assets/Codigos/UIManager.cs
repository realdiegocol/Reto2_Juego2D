using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI collectedText;
    public TextMeshProUGUI remainingText;

    // Update the UI Text elements based on the collected and remaining counts
    public void UpdateUI(int collected, int remaining)
    {
        collectedText.text = collected.ToString(); // Display only the number
        remainingText.text = remaining.ToString(); // Display only the number
    }
}



