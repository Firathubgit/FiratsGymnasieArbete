using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth2 : MonoBehaviour
{
    public Image healthBarPlayer2;

    [SerializeField] private AudioClip hurtSound;
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private int maxHealthPlayer2 = 100; // Maximum health
    public int currentHealthPlayer2; // Current health
    PlayerController playerController;
    Animator animator;
    CountdownTimer countdownTimer;
    // Start is called before the first frame update
    void Start()
    {
        countdownTimer = FindObjectOfType<CountdownTimer>();
        GameObject Parentparent = GameObject.Find("CharakterParentHolderWorkingLogicController");
        audioSource = Parentparent.GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        healthBarPlayer2 = GameObject.Find("Health2").GetComponent<Image>();
        playerController = GetComponent<PlayerController>();
        currentHealthPlayer2 = maxHealthPlayer2; // Initialize current health to max health at the start
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(currentHealthPlayer2);
    }

    public void TakeDamagePlayer2(int damageAmount)
    {
        currentHealthPlayer2 -= damageAmount;
        animator.SetTrigger("Hit");
        audioSource.PlayOneShot(hurtSound);
        CineMashineShake.Instance.ShakeCamera(1.5f, 0.3f);
        healthBarPlayer2.fillAmount = currentHealthPlayer2 / 100f;
        // Check for defeat or any other actions based on health reaching zero
        if (currentHealthPlayer2<= 0)
        {
            // Perform actions for defeat (e.g., play defeat animation, end game, etc.)
            // For example:

            Debug.Log("Player defeated!Player 2");
            animator.SetTrigger("Won");
            countdownTimer.StartCoroutine(countdownTimer.BackToMainMeny());
            //gameObject.SetActive(false); // Deactivate the player object
            // You can add further logic here for game over, reset, etc.
        }
    }

    public void OnTakeDamadgePlayer2()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Damage Taken Player 2");
            animator.SetTrigger("Hit");
            TakeDamagePlayer2(40); // Call the function to take damage
        }
    }
}
