using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Rigidbody2D enemyRB;
    [SerializeField] Animator enemyAnimator;
    int health = 3;

    // Patrol Variables
    public bool enemyPatrol = true;
    public float patrolSpeed = 30;

    // Flip Variables
    [SerializeField] Transform groundCheck;
    bool enemyTurn;
    [SerializeField] LayerMask Foreground;
    [SerializeField] Collider2D enemyCollider;

    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        enemyAnimator = GetComponent<Animator>();
        enemyPatrol = true;
    }
    void Update()
    {
       if(enemyPatrol)
       {
            // If enemyPatrol = true then call Patrol Function
            Patrol();
       }

        if (health < 0)
       {
            enemyAnimator.SetTrigger("Death");
            Destroy(gameObject, 1.4f);
       }
    }

    private void FixedUpdate()
    {
        // if statement while enemy is moving
        if(enemyPatrol)
        {
            // Returns true if groundCheck layer contains ground, and false if not
            enemyTurn = !Physics2D.OverlapCircle(groundCheck.position, 0.1f, Foreground);
        }
    }

    public void TakeDamage(int damage)
    {
        enemyAnimator.SetTrigger("Hurt");
        health -= damage;
    }

    // Patrol Function to make character walk
    void Patrol()
    {
        // Velocity to move character in right direction
        enemyRB.velocity = new Vector2(patrolSpeed * Time.fixedDeltaTime, enemyRB.velocity.y);

        if (enemyTurn || enemyCollider.IsTouchingLayers(Foreground))
        {
            // Flip character in left direction once end of platfrom reached or collider hits the wall
            Flip();
        }
    }

    // Flip Function
    public void Flip()
    {
        enemyPatrol = false;
        // Multiply x scale by -1 to flip
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        patrolSpeed *= -1;
        enemyPatrol = true;
    }
}