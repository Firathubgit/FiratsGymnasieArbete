using UnityEngine;
using TMPro;

public class TextSwitcher2 : MonoBehaviour
{
    public TextMeshProUGUI[] texts2; // Array of TextMeshPro objects representing options
    private int currentTextIndex2 = 0;

    void Start()
    {
        // Activate the initial text
        SetTextActive2(currentTextIndex2);
    }

    // Function to deactivate all texts except the specified index
    void SetTextActive2(int indexToActivate)
    {
        for (int i = 0; i < texts2.Length; i++)
        {
            texts2[i].gameObject.SetActive(i == indexToActivate);
        }
    }

    // Function to handle the right button press
    public void OnRightButtonPressed()
    {
        Debug.Log("RightPressed2");
        currentTextIndex2 = (currentTextIndex2 + 1) % texts2.Length;
        SetTextActive2(currentTextIndex2);
    }

    // Function to handle the left button press
    public void OnLeftButtonPressed()
    {
        Debug.Log("LeftPressed2");
        currentTextIndex2 = (currentTextIndex2 - 1 + texts2.Length) % texts2.Length;
        SetTextActive2(currentTextIndex2);
    }
}
