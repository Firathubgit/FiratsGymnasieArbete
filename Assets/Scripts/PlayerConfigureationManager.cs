using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerConfigureationManager : MonoBehaviour
{
    private List<PlayerConfigureation> PlayerConfigs;

    [SerializeField] GameObject[] DeaktivatedObjects;
    [SerializeField] GameObject[] AktivatedObjects;
    [SerializeField] int MaxPlayers;

    public static PlayerConfigureationManager Instance { get; private set; }

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.Log("SINGELTION - Trying to create another instance of singelton!");
        }
        else
        {
            Instance = this;
            PlayerConfigs = new List<PlayerConfigureation>();
        }
    }

    public List<PlayerConfigureation> GetPlayerConfigs()
    {
        return PlayerConfigs;
    }

    public void RedyPlayer(int index)
    {
        PlayerConfigs[index].IsRedy = true;
        if (PlayerConfigs.Count == MaxPlayers && PlayerConfigs.All(p => p.IsRedy == true))
        {
            

            Debug.Log("EveryPlayerIsRedy Script PLayerConfigurationManager");
            foreach (GameObject obj in AktivatedObjects)
            {
                if (!obj.activeSelf) // Check if the object is inactive
                {
                    obj.SetActive(true); // If inactive, set it to active
                }
            }
            foreach (GameObject obj in DeaktivatedObjects)
            {
                if (obj.activeSelf) // Check if the object is active
                {
                    obj.SetActive(false); // If active, set it to inactive
                }
            }
            PlayerConfigs.All(p => p.IsRedy == true);
            gameObject.SetActive(false);
        }
    }

    public void HandlePlayerJoin(PlayerInput pi)
    {
        Debug.Log("PLayerJoined" + pi.playerIndex);
        if(!PlayerConfigs.Any(p => p.PlayerIndex == pi.playerIndex))
        {
            pi.transform.SetParent(transform);
            PlayerConfigs.Add(new PlayerConfigureation(pi));
        }
    }
    
}

public class PlayerConfigureation
{
    public PlayerConfigureation(PlayerInput pi)
    {
        PlayerIndex = pi.playerIndex;
        input = pi;
    }
    public PlayerInput input { get; set; }
    public int PlayerIndex { get; set; }
    public bool IsRedy { get; set; }
}