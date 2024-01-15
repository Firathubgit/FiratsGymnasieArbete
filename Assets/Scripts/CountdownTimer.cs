using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    public TextMeshProUGUI countdownText;
    public bool gameStart = false;
    public float countdownDuration = 100f;
    public GameObject gameFinishedTextShow;

    private float countdownTimer;

    void Start()
    {
        countdownTimer = countdownDuration;
        // Set initial text
        UpdateCountdownText();
        gameFinishedTextShow.SetActive(false);
    }

    void Update()
    {
        if (gameStart)
        {
            if (countdownTimer > 0)
            {
                countdownTimer -= Time.deltaTime;
                UpdateCountdownText();
                
            }
            else
            {
                // Countdown finished, do something when timer reaches 0
                // For example: End the fight or trigger an event
                countdownTimer = 0;
                StartCoroutine(BackToMainMeny());
            }
        }
    }

    void UpdateCountdownText()
    {
        int timeLeft = Mathf.CeilToInt(countdownTimer);
        countdownText.text = timeLeft.ToString();
    }

    public IEnumerator BackToMainMeny()
    {
        gameFinishedTextShow.SetActive(true);
        Time.timeScale = 0.5f;
        yield return new WaitForSeconds(3f);
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
