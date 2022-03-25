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
    float playerSpeed = 3000;
    float JumpSpeed = 20;

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
        if (playerHorizontalMove)
        {
            // Returns sign of velocity 
            transform.localScale = new Vector3(Mathf.Sign(playerRB.velocity.x) * 1, 1, 1);
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
        bool IsTouchingGround = playerCollider.IsTouchingLayers(LayerMask.GetMask("Foreground"));

        if (Input.GetButtonDown("Jump"))
        {
            if (IsTouchingGround)
            {
                Vector2 JumpVelocity = new Vector2(0, JumpSpeed);
                playerRB.velocity += JumpVelocity;
                playerAnimator.SetBool("Jump", !IsTouchingGround);
            }
            
        }
    }

}


