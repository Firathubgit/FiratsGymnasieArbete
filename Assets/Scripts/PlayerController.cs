using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private int playerIndex = 0;


    public Animator animator;
    CountdownTimer countdownTimer;
    private bool isFacingRight = true;
    [SerializeField] private GameObject attackCollider;
    [SerializeField] private GameObject kickCollider;

    [Header("Player Variables")]

    [SerializeField] private float walkSpeed = 2.0f;
    [SerializeField] private float jumpForce = 5.0f; // Add jump force
    [SerializeField] private float jumpDelayTime = 5.0f; // Add jump force

    [Header("CutScene")]
    [SerializeField] private float cutsceneDuration = 22.0f; // Set the duration of the cutscene
    private float cutsceneTimer = 0.0f;

    private Vector2 moveInput;
    private bool isPunching;
    private bool isKicking;
    private bool isBackSpinKicking;
    private bool isJumping; // New variable for jumping
    private bool canKick;
    private bool isNotAttacking;
    private bool canMove = false;

    [Header("AudioClipRelated")]
    [SerializeField] private AudioClip punchSound;
    [SerializeField] private AudioClip kickSound;
    [SerializeField] private AudioClip jumpSound;

    [SerializeField] private AudioSource audioSource;

    [Header("Balenceing Variables")]
    public float kickDelay = 2.0f; // Time delay before trigger can be set again
    public float afterKickWalkTime;
    public float afterPunchWalkTime;
    private float lastKickTriggerTime;



    private Rigidbody rb; // Rigidbody component

    private void Start()
    {
        GameObject Parentparent = GameObject.Find("CharakterParentHolderWorkingLogicController");
        audioSource = Parentparent.GetComponent<AudioSource>();
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        countdownTimer = FindAnyObjectByType<CountdownTimer>();
        kickCollider.SetActive(false);
        attackCollider.SetActive(false);
        isNotAttacking = true;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Increment the timer while the cutscene is playing
        if (!canMove)
        {
            cutsceneTimer += Time.deltaTime;

            // Check if the cutscene duration has passed
            if (cutsceneTimer >= cutsceneDuration)
            {
                // Enable player movement after the cutscene duration
                canMove = true;
                countdownTimer.gameStart = true;
                // Add logic here to enable player controls or input
                // For example: Unlocking player movement or enabling controls
            }
        }

        Debug.Log(isNotAttacking);
        float moveDirection = moveInput.x;
        Debug.Log(moveDirection);

        if (isNotAttacking)
        {
            // Determine the walking direction based on character's facing direction
            float moveSpeed = 0;
            bool isWalkingForward = false;
            bool isWalkingBackward = false;

            if (moveDirection > 0 && isFacingRight)
            {
                // Walking forwards
                isWalkingForward = true;
            }
            else if (moveDirection < 0 && !isFacingRight)
            {
                // Walking backward
                isWalkingBackward = true;
            }

            // Set the walking animation parameters
            animator.SetBool("IsWalkingForward", isWalkingForward);
            animator.SetBool("IsWalkingBackward", isWalkingBackward);

            moveSpeed = moveDirection * walkSpeed;

            Vector3 moveVector = new Vector3(0, 0, moveSpeed);
            transform.Translate(moveVector * Time.deltaTime);

            // Flip the character when changing direction
            if (moveDirection > 0 && !isFacingRight)
            {
                FlipCharacter();
            }
            else if (moveDirection < 0 && isFacingRight)
            {
                FlipCharacter();
            }

            // Handle jumping input
            if (isJumping)
            {
                //JumpLogic Goes through this if statment
                StartCoroutine(JumpDelay());
                Debug.Log("Jumped");
            }
        }

        // Update animator parameters
        animator.SetBool("IsPunching", isPunching);
        animator.SetBool("IsKicking", isKicking);
        //(BackSpin is not added yet!...)
        animator.SetBool("IsBackSpinKicking", isBackSpinKicking);
        animator.SetBool("IsJumping", isJumping); // Update jumping parameter
    }

    public int GetPlayerIndex()
    {
        //Returns playerIndex
        return playerIndex;
    }

    public void OnMove(InputValue value)
    {
        if (canMove)
        {
            //Get the moveInputValue
            moveInput = value.Get<Vector2>();
        }
    }

    public void OnFire()
    {
        if (canMove)
        {
            if (!isPunching)
            {
                //OnFire Logic
                audioSource.PlayOneShot(punchSound);
                attackCollider.SetActive(true);
                isPunching = true;
                animator.SetTrigger("Punch");
                isNotAttacking = false;
                StartCoroutine(ResetPunch());
            }

        }
    }

    public void OnKick()
    {
        if (!isKicking)
        {
            //On Kick Logic
            kickCollider.SetActive(true);
            isKicking = true;
            if (Time.time - lastKickTriggerTime > kickDelay)
            {
                audioSource.PlayOneShot(kickSound);
                SendKickTrigger();
            }
            StartCoroutine(ResetKick());
        }
    }
    private void SendKickTrigger()
    {
        animator.SetTrigger("Kick");
        isNotAttacking = false;
        // Update the last trigger time
        lastKickTriggerTime = Time.time;
    }


    //BackSpinKick is not added yet...
    public void OnBackSpinKick()
    {
        if (!isBackSpinKicking)
        {
            isBackSpinKicking = true;
            animator.SetTrigger("BackSpinKick");
            StartCoroutine(ResetBackSpinKick());
        }
    }

    public void OnJump()
    {
        //Jumps on line 128
        //Jump logic and can move check
        if (canMove)
        {
            Debug.Log("Pressed");
            if (!isJumping)
            {
                audioSource.PlayOneShot(jumpSound);
                animator.SetTrigger("Jump");
                isJumping = true;
            }
        }
    }


    //Jumps on line 128
    private void Jump()
    {
        if (canMove)
        {
            Debug.Log("JUMPKÖRS");
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            isJumping = false;
        }

    }

    private IEnumerator ResetPunch()
    {
        //Delay after punch is possible
        yield return new WaitForSeconds(afterPunchWalkTime);
        attackCollider.SetActive(false);
        isPunching = false;
        isNotAttacking = true;
    }

    private IEnumerator ResetKick()
    {
        //Delay after kick is possible
        yield return new WaitForSeconds(afterKickWalkTime);
        kickCollider.SetActive(false);
        isKicking = false;
        isNotAttacking = true;
    }

    private IEnumerator ResetBackSpinKick()
    {
        //Back spin kick is not in the game but still in the script as future plans on addition for the game
        yield return new WaitForSeconds(afterPunchWalkTime);
        isNotAttacking = true;
        isBackSpinKicking = false;
    }

    private IEnumerator JumpDelay()
    {
        yield return new WaitForSeconds(jumpDelayTime);
        Jump();
    }

    private void FlipCharacter()    
    {
        isFacingRight = !isFacingRight;
        /*Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;*/
    }
}
