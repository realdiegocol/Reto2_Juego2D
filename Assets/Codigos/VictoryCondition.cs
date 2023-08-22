using UnityEngine;

public class VictoryCondition : MonoBehaviour
{
    public LevelInteractionManager interactionManager; // Reference to the LevelInteractionManager script

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Call the method to show the Victory panel using the reference to LevelInteractionManager
            interactionManager.ShowVictoryPanel();

            // Disable the character's movement
            CharacterController characterController = collision.GetComponent<CharacterController>();
            if (characterController != null)
            {
                characterController.enabled = false;
            }
        }
    }
}
