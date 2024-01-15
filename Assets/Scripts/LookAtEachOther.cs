using UnityEngine;
using System.Collections.Generic;

public class LookAtEachOther : MonoBehaviour
{
    // This script is a work in progress.
    public Transform leftParent;
    public Transform rightParent;
    public float thresholdDistance = 2.0f; // Adjust this value for your game

    private GameObject[] leftPlayers;
    private GameObject[] rightPlayers;

    private int leftPlayerDirection = 1;
    private int rightPlayerDirection = -1;

    void Update()
    {
        // Get active children under left and right parents
        leftPlayers = GetActiveChildren(leftParent);
        rightPlayers = GetActiveChildren(rightParent);

        if (leftPlayers.Length > 0 && rightPlayers.Length > 0)
        {
            // Get the currently active left and right players
            GameObject activeLeftPlayer = GetActivePlayer(leftPlayers);
            GameObject activeRightPlayer = GetActivePlayer(rightPlayers);

            // Check if the distance between active left and right players is less than the threshold
            if (Vector3.Distance(activeLeftPlayer.transform.position, activeRightPlayer.transform.position) < thresholdDistance)
            {
                Debug.Log("Players moved past each other!");

                // Determine the direction of movement for the left and right players
                int newLeftDirection = Mathf.RoundToInt(Mathf.Sign(activeRightPlayer.transform.position.x - activeLeftPlayer.transform.position.x));
                int newRightDirection = Mathf.RoundToInt(Mathf.Sign(activeLeftPlayer.transform.position.x - activeRightPlayer.transform.position.x));

                // Flip the left player's scale if the direction changes
                if (newLeftDirection != leftPlayerDirection)
                {
                    leftPlayerDirection = newLeftDirection;
                    activeLeftPlayer.transform.localScale = new Vector3(leftPlayerDirection * Mathf.Abs(activeLeftPlayer.transform.localScale.x), activeLeftPlayer.transform.localScale.y, activeLeftPlayer.transform.localScale.z);
                }

                // Flip the right player's scale if the direction changes
                if (newRightDirection != rightPlayerDirection)
                {
                    rightPlayerDirection = newRightDirection;
                    activeRightPlayer.transform.localScale = new Vector3(rightPlayerDirection * Mathf.Abs(activeRightPlayer.transform.localScale.x), activeRightPlayer.transform.localScale.y, activeRightPlayer.transform.localScale.z);
                }
            }
        }
    }

    // Get active children of a parent and return them as an array
    GameObject[] GetActiveChildren(Transform parent)
    {
        List<GameObject> activeChildren = new List<GameObject>();

        for (int i = 0; i < parent.childCount; i++)
        {
            GameObject child = parent.GetChild(i).gameObject;
            if (child.activeSelf)
            {
                activeChildren.Add(child);
            }
        }

        return activeChildren.ToArray();
    }

    // Get the first active player from an array of players
    GameObject GetActivePlayer(GameObject[] players)
    {
        foreach (GameObject player in players)
        {
            if (player.activeSelf)
            {
                return player;
            }
        }
        return null;
    }
}
