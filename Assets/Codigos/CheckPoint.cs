using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    // Reference to the AudioSource component
    private AudioSource audioSource;

    // Reference to the AudioClip for the checkpoint sound
    public AudioClip checkpointSound;

    // Flag to track whether the sound has been played
    private bool soundPlayed = false;

    private void Start()
    {
        // Get the AudioSource component on the same GameObject
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player") && !soundPlayed)
        {
            col.gameObject.GetComponent<CharacterController>().posicionInicio = transform.position;

            // Play the checkpoint sound
            if (audioSource != null && checkpointSound != null)
            {
                audioSource.PlayOneShot(checkpointSound);
                soundPlayed = true; // Set the flag to true
            }
        }
    }
}
   