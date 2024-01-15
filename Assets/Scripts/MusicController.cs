using UnityEngine;

public class MusicController : MonoBehaviour
{
    // Static instance to ensure there is only one MusicController in the scene
    private static MusicController instance;

    // Reference to the AudioSource for music playback
    public AudioSource musicAudioSource;

    private void Awake()
    {
        // Ensure there is only one instance of MusicController
        if (instance != null && instance != this)
        {
            // Destroy any duplicate instances
            Destroy(gameObject);
            return;
        }

        // Set the current instance as the active instance
        instance = this;

        // Make the MusicController object persist across scenes
        DontDestroyOnLoad(gameObject);

        // Check if the musicAudioSource is not assigned
        if (musicAudioSource == null)
        {
            // Log an error message if the AudioSource is not assigned
            Debug.LogError("Music Audio Source not assigned!");
        }
    }

    // Method to play music
    public void PlayMusic()
    {
        // Check if the musicAudioSource is assigned
        if (musicAudioSource != null)
        {
            // Check if the music is not already playing
            if (!musicAudioSource.isPlaying)
            {
                // Play the music
                musicAudioSource.Play();
            }
        }
        else
        {
            // Log an error message if the AudioSource is not assigned
            Debug.LogError("Music Audio Source not assigned!");
        }
    }
}
