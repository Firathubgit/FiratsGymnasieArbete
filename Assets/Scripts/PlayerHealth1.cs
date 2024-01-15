using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth1 : MonoBehaviour
{
    public Image healthBarPlayer1;

    [SerializeField] private AudioClip hurtSound;
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private int maxHealthPlayer1 = 100; // Maximum health
    public int currentHealthPlayer1; // Current health
    PlayerController playerController;
    Animator animator;
    CountdownTimer countdownTimer;
    // Start is called before the first frame update
    void Start()
    {
        countdownTimer = FindObjectOfType<CountdownTimer>();
        GameObject Parentparent = GameObject.Find("CharakterParentHolderWorkingLogicController");
        audioSource = Parentparent.GetComponent<AudioSource>();
        healthBarPlayer1 = GameObject.Find("Health1").GetComponent<Image>();
        animator = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
        currentHealthPlayer1 = maxHealthPlayer1; // Initialize current health to max health at the start
    }

    public void TakeDamagePlayer1(int damageAmount)
    {
        currentHealthPlayer1 -= damageAmount;
        animator.SetTrigger("Hit");
        audioSource.PlayOneShot(hurtSound);
        CineMashineShake.Instance.ShakeCamera(1.5f, 0.3f);
        healthBarPlayer1.fillAmount = currentHealthPlayer1 / 100f;

        // Check for defeat or any other actions based on health reaching zero
        if (currentHealthPlayer1 <= 0)
        {
            // Perform actions for defeat (e.g., play defeat animation, end game, etc.)
            // For example:
            Debug.Log("Player defeated!Player 1");
            animator.SetTrigger("Won");
            countdownTimer.StartCoroutine(countdownTimer.BackToMainMeny());
            //gameObject.SetActive(false); // Deactivate the player object
            // You can add further logic here for game over, reset, etc.
        }
    }

}
