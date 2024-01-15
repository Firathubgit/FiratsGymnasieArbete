using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneMapActivator : MonoBehaviour
{
    [Header("Map Materials")]
    public Material defaultSkybox; // Default skybox material if selected skybox is not found
    public Material skyboxScene1;
    public Material skyboxScene2;
    public Material skyboxScene3;
    public Material skyboxScene4;

    [Header("Light Intensities")]
    public float intensityScene1 = 1f;
    public float intensityScene2 = 0.8f;
    public float intensityScene3 = 0.5f;
    public float intensityScene4 = 0.3f;

    public GameObject mapsContainer; // Reference to the container holding the maps
    public Light directionalLight; // Reference to the directional light

    private void Start()
    {
        string selectedMapReference = PlayerPrefs.GetString("SelectedMapReference");

        Transform selectedMap = mapsContainer.transform.Find(selectedMapReference);

        if (selectedMap != null)
        {
            foreach (Transform map in mapsContainer.transform)
            {
                if (map != selectedMap)
                {
                    map.gameObject.SetActive(false);
                }
            }

            selectedMap.gameObject.SetActive(true);

            Material selectedSkybox = GetSkyboxForMap(selectedMap.gameObject);

            if (selectedSkybox != null)
            {
                RenderSettings.skybox = selectedSkybox;
                AdjustDirectionalLightIntensity(selectedMap.gameObject);
            }
            else
            {
                Debug.LogWarning("Selected skybox material not found, using default.");
                RenderSettings.skybox = defaultSkybox;
                AdjustDirectionalLightIntensity(null);
            }
        }
        else
        {
            Debug.LogWarning("Selected map not found within the container!");
        }
    }

    private Material GetSkyboxForMap(GameObject map)
    {
        // Map the active map's game object to the corresponding skybox material
        if (map.CompareTag("Scene1"))
        {
            return skyboxScene1;
        }
        else if (map.CompareTag("Scene2"))
        {
            return skyboxScene2;
        }
        else if (map.CompareTag("Scene3"))
        {
            return skyboxScene3;
        }
        else if (map.CompareTag("Scene4"))
        {
            return skyboxScene4;
        }

        return null; // Return null if no matching material found
    }

    private void AdjustDirectionalLightIntensity(GameObject map)
    {
        // Set the emission intensity of the directional light based on the active map
        if (map.CompareTag("Scene1"))
        {
            directionalLight.intensity = intensityScene1;
        }
        else if (map.CompareTag("Scene2"))
        {
            directionalLight.intensity = intensityScene2;
        }
        else if (map.CompareTag("Scene3"))
        {
            directionalLight.intensity = intensityScene3;
        }
        else if (map.CompareTag("Scene4"))
        {
            directionalLight.intensity = intensityScene4;
        }
        else
        {
            directionalLight.intensity = 1.0f; // Set default intensity if no matching map found
        }
    }
}
