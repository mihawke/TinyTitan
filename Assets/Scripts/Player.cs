using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private InputSystem_Actions inputActions;
    private Rigidbody2D rb;
    private float moveSpeed = 5f;
    private float jumpForce = 10f;
    [SerializeField] private int maxJumps = 1;
    private int jumpsRemaining;
    public int playerHealth = 100;
    [SerializeField] Image healthImage;
    public int coins = 0;


    [SerializeField] PlayerAnimation playerAnimation;

    //
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    private bool isGrounded;

    private void Awake()
    {
        inputActions = new InputSystem_Actions();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void Update()
    {
        CheckGrounded();
        float move = 0f;
        if (inputActions.Player.Left.IsPressed())
        {
            move = -1f;
        }
        if (inputActions.Player.Right.IsPressed())
        {
            move = 1f;
        }
        if (isGrounded)
        {
            jumpsRemaining = maxJumps;
        }
        if (inputActions.Player.Up.WasPressedThisFrame() && jumpsRemaining > 0)
        {
            rb.linearVelocityY = jumpForce;
            jumpsRemaining--;
        }
        rb.linearVelocityX = move * moveSpeed;
        SetAnimation(move);
        healthImage.fillAmount = playerHealth / 100f;
    }
    private void CheckGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }

    private void SetAnimation(float moveInput)
    {
        if (isGrounded)
        {
            if (moveInput == 0)
            {
                playerAnimation.CurrentAnimation(PlayerAnimation.AnimationState.Player_Idle);
            }
            else
            {
                playerAnimation.CurrentAnimation(PlayerAnimation.AnimationState.Player_Run);
            }
        }
        else
        {
            if (rb.linearVelocityY > 0)
            {
                playerAnimation.CurrentAnimation(PlayerAnimation.AnimationState.Player_Jump);
            }
            else
            {
                playerAnimation.CurrentAnimation(PlayerAnimation.AnimationState.Player_Fall);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag == "Damage")
        {
            playerHealth -= 25;
            rb.linearVelocityY = jumpForce;

            //for timed functions
            StartCoroutine(playerAnimation.BlinkRed());

            if (playerHealth <= 0)
            {
                PlayerDied();
            }
        }
    }

    private void PlayerDied()
    {
        SceneManager.LoadScene("SampleScene");
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag == "GoldCoin")
        {
            coins += 5;
            Debug.Log(coins);
        }
        if (collider2D.gameObject.tag == "BronzeCoin")
        {
            coins += 1;
            Debug.Log(coins);
        }
        if (collider2D.gameObject.tag == "SilverCoin")
        {
            coins += 2;
            Debug.Log(coins);
        }
        if (collider2D.gameObject.tag == "Flag")
        {
            Debug.Log("Finished!");
        }
    }
}
