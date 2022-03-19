using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D playerRB;
    Animator playerAnimator;

    [SerializeField] float playerSpeed;

    // Jump Variables
    [SerializeField] float jumpForce;
    bool isGrounded;
    const float groundCheck = 0.2f;
    [SerializeField] Transform groundCheckCollider;
    [SerializeField] LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    { 
        bool playerHorizontalMove = Mathf.Abs(playerRB.velocity.y) > 0;
        // Flips player sprite based on movement
        if (playerHorizontalMove)
        {
            // Returns sign of velocity 
            transform.localScale = new Vector3(Mathf.Sign(playerRB.velocity.x)* 1,1,1);
        }

        float controlThrow = Input.GetAxis("Horizontal") * Time.deltaTime;
        Vector2 playerVelocity = new Vector2(controlThrow * playerSpeed, playerRB.velocity.y); // Velocity is 2D vector
        playerRB.velocity = playerVelocity;

        // Passing straight to value
        playerAnimator.SetBool("CanWalk", playerHorizontalMove);

        // Checking if player grounded before jumping
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isGrounded = Physics2D.OverlapCircle(groundCheckCollider.position, groundCheck, groundLayer);
            if (isGrounded)
            {
                Jump();
            }
        }
    }

    void Jump()
    {
        playerRB.velocity = Vector2.up * jumpForce;
    }
}
