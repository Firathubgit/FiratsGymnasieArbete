using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkyBoxSceneChanger : MonoBehaviour
{
    // Reference to the ButtonClickSoundController
    ButtonClickSoundController buttonClickSoundController;

    [Header("Scene1")]
    [SerializeField] GameObject oldSeaPortMap;
    [SerializeField] string skyboxIdentifierScene1 = "ErieBlackOldSeaPort";

    [Header("Scene2")]
    [SerializeField] GameObject Map2;
    [SerializeField] string skyboxIdentifierScene2 = "Material2"; // Adjust this identifier

    [Header("Scene3")]
    [SerializeField] GameObject Map3;
    [SerializeField] string skyboxIdentifierScene3 = "Material3"; // Adjust this identifier

    [Header("Scene4")]
    [SerializeField] GameObject Map4;
    [SerializeField] string skyboxIdentifierScene4 = "Material4"; // Adjust this identifier

    private GameObject selectedMap;
    private string selectedSkyboxIdentifier;

    private void Start()
    {
        // Find and store the ButtonClickSoundController script in the scene
        buttonClickSoundController = FindObjectOfType<ButtonClickSoundController>();
    }

    // Method to be called when selecting Map1
    public void SelectMap1()
    {
        // Set the selected map and skybox identifier for Scene1
        selectedMap = oldSeaPortMap;
        selectedSkyboxIdentifier = skyboxIdentifierScene1;
        LoadNextScene();
    }

    // Method to be called when selecting Map2
    public void SelectMap2()
    {
        // Set the selected map and skybox identifier for Scene2
        selectedMap = Map2;
        selectedSkyboxIdentifier = skyboxIdentifierScene2;
        LoadNextScene();
    }

    // Method to be called when selecting Map3
    public void SelectMap3()
    {
        // Set the selected map and skybox identifier for Scene3
        selectedMap = Map3;
        selectedSkyboxIdentifier = skyboxIdentifierScene3;
        LoadNextScene();
    }

    // Method to be called when selecting Map4
    public void SelectMap4()
    {
        // Set the selected map and skybox identifier for Scene4
        selectedMap = Map4;
        selectedSkyboxIdentifier = skyboxIdentifierScene4;
        LoadNextScene();
    }

    // Method to initiate the scene transition
    private void LoadNextScene()
    {
        // Play click sound and initiate a delay
        buttonClickSoundController.PlayClickSound();
        StartCoroutine(AllEverythingDelay(1f));

        // Store the selected map and skybox identifier in PlayerPrefs for the next scene
        PlayerPrefs.SetString("SelectedMapReference", selectedMap.name);
        PlayerPrefs.SetString("SelectedSkyboxIdentifier", selectedSkyboxIdentifier);
    }

    // Coroutine for introducing a delay
    IEnumerator AllEverythingDelay(float duration)
    {
        // Introduce a delay before performing the next action
        yield return new WaitForSeconds(duration);
    }
}
