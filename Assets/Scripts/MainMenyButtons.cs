using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenyButtons : MonoBehaviour
{
    // URL to open when the OpenURL button is clicked
    private string urlToOpen = "https://www.instagram.com/atal_moretti/";

    // Reference to ButtonClickSoundController
    ButtonClickSoundController buttonClickSoundController;

    // Offset to determine the next scene build index
    public int sceneOffset = 1;

    // Reference to the transition animator for scene transitions
    [SerializeField] Animator transitionAnimator;

    private void Start()
    {
        // Find and store the ButtonClickSoundController script in the scene
        buttonClickSoundController = FindObjectOfType<ButtonClickSoundController>();
    }

    // Method to be called when the "Play" button is clicked
    public void PlayButton()
    {
        // Play click sound and initiate the scene loading coroutine
        buttonClickSoundController.PlayClickSound();
        StartCoroutine(LoadLevel());
    }

    // Method to be called when the "OpenURL" button is clicked
    public void OpenURL()
    {
        // Open the specified URL in the default web browser
        Application.OpenURL(urlToOpen);
    }

    // Method to be called when the "Quit" button is clicked
    public void QuitButton()
    {
        // Quit the application when the "Quit" button is clicked
        Application.Quit();
    }

    // Coroutine to handle the scene loading transition
    IEnumerator LoadLevel()
    {
        // Make the MainMenyButtons object persist across scenes
        DontDestroyOnLoad(gameObject);

        // Trigger the "End" animation in the transition animator
        transitionAnimator.SetTrigger("End");
        yield return new WaitForSeconds(0.3f);

        // Get the current scene's build index
        int currentSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;

        // Calculate the next scene's build index using the offset
        int nextSceneBuildIndex = currentSceneBuildIndex + sceneOffset;

        // Load the next scene
        SceneManager.LoadScene(nextSceneBuildIndex);

        // Introduce a delay before triggering the "Start" animation
        yield return new WaitForSeconds(1f);

        // Trigger the "Start" animation in the transition animator
        transitionAnimator.SetTrigger("Start");
    }
}
