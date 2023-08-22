using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interaccion : MonoBehaviour
{
    public UnityEvent entro;
    public UnityEvent salio;

    public Health health; // Reference to the Health script

    private void Start()
    {
        // Make sure to assign the Health reference in the Inspector
        if (health == null)
        {
            health = GameObject.FindObjectOfType<Health>();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            
                // Play trap collision sound
                AudioSource audioSource = GetComponent<AudioSource>();
                if (audioSource != null)
                {
                    audioSource.Play();
                }

                // Reduce health when colliding with traps
                health.ReduceHealth(1);
            
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            entro.Invoke();
            if (col.gameObject.CompareTag("Bombillo"))
            {
                // Play 'Bombillo' collection sound
                AudioSource audioSource = GetComponent<AudioSource>();
                if (audioSource != null)
                {
                    audioSource.Play();
                }

                // Handle light bulb collection logic here if needed
            }
        }
    }

    // Other collision methods...

    // Update, Exit, and other methods...
}
