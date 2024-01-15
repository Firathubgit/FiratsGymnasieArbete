using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSetupMenuController : MonoBehaviour
{

    public int PlayerIndex;

    [SerializeField] private GameObject readyPanel;

    [SerializeField] private Button readyButton;

    private float ignoreInputTime = 0f;
    private bool inputEnabled;

    public void SetPlayerIndex(int pi)
    {
        PlayerIndex = pi;
        
        ignoreInputTime = Time.time + ignoreInputTime;
    }
    // Update is called once per frame
    void Update()
    {
        if(Time.time > ignoreInputTime)
        {
            inputEnabled = true;
        }
    }

    public void ReadyPlayer()
    {
        if (!inputEnabled) { return; }
        PlayerConfigureationManager.Instance.RedyPlayer(PlayerIndex);
        readyButton.gameObject.SetActive(false);
    }

}
