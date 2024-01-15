using UnityEngine;
using UnityEngine.UI;

public class ButtonClickSoundController : MonoBehaviour
{
    public static ButtonClickSoundController Instance { get; private set; }
    public AudioClip clickSound; // Sound clip to play
    private Button button;
    private AudioSource audioSource;

    void Start()
    {
        // Get or add an AudioSource component to the GameObject
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Assign the click sound to the AudioSource
        audioSource.clip = clickSound;
    }

    public void PlayClickSound()
    {
        // Play the assigned click sound when the button is clicked
        audioSource.PlayOneShot(clickSound);
        Debug.Log("TrypLAY");
    }
}
