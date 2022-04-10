using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Component References
    Rigidbody2D playerRB;
    Animator playerAnimator;
    Collider2D playerCollider;

    // Variables
    float playerSpeed = 2500;
    float JumpSpeed = 18;

    // Public to access it from the HUDScript class
    [HideInInspector] public int KeyCollected { get; private set; } = 0;

    void Start()
    {
        // Component References
        playerRB = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        bool playerHorizontalMove = PlayerMovement();
        AnimationChange(playerHorizontalMove);
        PlayerJump();
    }

    private void AnimationChange(bool playerHorizontalMove)
    {
        // Changing the animator controller variable to play different animations
        playerAnimator.SetBool("Walk", playerHorizontalMove);
    }

    private bool PlayerMovement()
    {
        // Flips player sprite based on movement
        bool playerHorizontalMove = Mathf.Abs(playerRB.velocity.y) > 0;
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if ((Input.GetAxis("Horizontal") > 0))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        // Getting input and moving the character
        float controlThrow = Input.GetAxis("Horizontal") * Time.deltaTime;
        Vector2 playerVelocity = new Vector2(controlThrow * playerSpeed, playerRB.velocity.y); // Velocity is 2D vector
        playerRB.velocity = playerVelocity;

        return playerHorizontalMove;
    }

    // Jump Method
    private void PlayerJump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            bool IsTouchingGround = playerCollider.IsTouchingLayers(LayerMask.GetMask("Foreground"));

            if (IsTouchingGround)
            {
                Vector2 JumpVelocity = new Vector2(0, JumpSpeed);
                playerRB.velocity += JumpVelocity;
            }
            playerAnimator.SetBool("Jump", true);
        }
        else
        {
            playerAnimator.SetBool("Jump", false);
        }
    }

    // Colection Method
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If Key Collected
        if (collision.gameObject.CompareTag("Key"))
        {
            // Add to key count
            KeyCollected++;
            // Destroy key object
            Destroy(collision.gameObject);
        }

    }
}

