using UnityEngine;
using TMPro;

public class TextSwitcher : MonoBehaviour
{
    public TextMeshProUGUI[] leftTexts; // Array of TextMeshPro objects for left player options
    public GameObject[] leftPlayerObjects; // Array of GameObjects for left player setup
    private int currentLeftTextIndex = 0; // Separate index for left player setup
    public TextMeshProUGUI[] rightTexts; // Array of TextMeshPro objects for right player options
    public GameObject[] rightPlayerObjects; // Array of GameObjects for right player setup
    private int currentRightTextIndex = 0; // Separate index for right player setup
    [SerializeField] bool PlayerOneRedy = false;
    [SerializeField] bool PlayerTwoRedy = false;
    public GameObject LeftParent;
    public GameObject RightParent;

    public PlayerSetupMenuController playerSetupMenuController;

    void Start()
    {
        RightParent = GameObject.Find("RightPlayers");
        LeftParent = GameObject.Find("LeftPlayers");
        SetTextActive();
    }

    private void Update()
    {
        Debug.Log("Current Left textIndex Is" + currentLeftTextIndex);
        Debug.Log("Current Right textIndex Is" + currentRightTextIndex);
    }
    void SetTextActive()
    {
        int setupPlayerSetupMenuIndex = playerSetupMenuController.PlayerIndex;

        if (setupPlayerSetupMenuIndex == 0) // Left player setup menu index
        {
            for (int i = 0; i < leftTexts.Length; i++)
            {
                leftTexts[i].gameObject.SetActive(i == currentLeftTextIndex);
                leftPlayerObjects[i].SetActive(i == currentLeftTextIndex);
            }
        }
        else if (setupPlayerSetupMenuIndex == 1) // Right player setup menu index
        {
            for (int i = 0; i < rightTexts.Length; i++)
            {
                rightTexts[i].gameObject.SetActive(i == currentRightTextIndex);
                rightPlayerObjects[i].SetActive(i == currentRightTextIndex);
            }
        }
    }

    public void OnRightButtonPressed()
    {
        int setupPlayerSetupMenuIndex = playerSetupMenuController.PlayerIndex;

        if (setupPlayerSetupMenuIndex == 0)
        {
            currentLeftTextIndex = (currentLeftTextIndex + 1) % leftTexts.Length;
        }
        else if (setupPlayerSetupMenuIndex == 1)
        {
            currentRightTextIndex = (currentRightTextIndex + 1) % rightTexts.Length;
        }

        SetTextActive();
    }

    public void OnLeftButtonPressed()
    {
        int setupPlayerSetupMenuIndex = playerSetupMenuController.PlayerIndex;

        if (setupPlayerSetupMenuIndex == 0)
        {
            currentLeftTextIndex = (currentLeftTextIndex - 1 + leftTexts.Length) % leftTexts.Length;
        }
        else if (setupPlayerSetupMenuIndex == 1)
        {
            currentRightTextIndex = (currentRightTextIndex - 1 + rightTexts.Length) % rightTexts.Length;
        }

        SetTextActive();
    }

    public void OnSelectionConfirmed()
    {
        int setupPlayerSetupMenuIndex = playerSetupMenuController.PlayerIndex;

        if (setupPlayerSetupMenuIndex == 0)
        {
            PlayerOneRedy = true;
            GameObject selectedGameObject = leftPlayerObjects[currentLeftTextIndex];
            Instantiate(selectedGameObject, new Vector3(0f, 0f, 0f), Quaternion.identity,RightParent.transform);
            selectedGameObject.SetActive(true);
            Debug.Log(selectedGameObject);

            // Perform actions for left player setup...
        }
        else if (setupPlayerSetupMenuIndex == 1)
        {
            PlayerTwoRedy = true;
            GameObject selectedGameObject = rightPlayerObjects[currentRightTextIndex];
            Instantiate(selectedGameObject, new Vector3(0f,0f,0f), Quaternion.identity, LeftParent.transform);
            selectedGameObject.SetActive(true);
            //selectedGameObject.SetActive(true);
            Debug.Log(selectedGameObject);
            // Perform actions for right player setup...
        }
    }
}
