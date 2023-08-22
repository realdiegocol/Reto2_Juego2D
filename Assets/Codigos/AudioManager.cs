using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Reference to the AudioSource component for background music
    public AudioSource backgroundMusic;

    // Start is called before the first frame update
    void Start()
    {
        // Play the background music
        if (backgroundMusic != null)
        {
            backgroundMusic.Play();
        }
    }

    // Other methods for controlling the music, like pausing or stopping
    public void PauseMusic()
    {
        if (backgroundMusic != null)
        {
            backgroundMusic.Pause();
        }
    }

    public void StopMusic()
    {
        if (backgroundMusic != null)
        {
            backgroundMusic.Stop();
        }
    }
}
