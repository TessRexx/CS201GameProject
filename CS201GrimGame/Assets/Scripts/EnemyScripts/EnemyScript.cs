using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Rigidbody2D enemyRB { get; private set; }
    [SerializeField] Animator enemyAnimator;
    [SerializeField] int health;

    // Patrol Variables
    public bool EnemyPatrol = true;
    public float PatrolSpeed;

    // Flip Variables
    [SerializeField] Transform groundCheck;
    bool enemyTurn;
    [SerializeField] LayerMask Foreground;
    [SerializeField] Collider2D enemyCollider;

    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        enemyAnimator = GetComponent<Animator>();
        EnemyPatrol = true;
    }
    void Update()
    {
       if(EnemyPatrol)
       {
            // If enemyPatrol = true then call Patrol Function
            enemyAnimator.SetBool("Walk", true);
            Patrol();
       }
    }

    private void FixedUpdate()
    {
        // if statement while enemy is moving
        if(EnemyPatrol)
        {
            // Returns true if groundCheck layer contains ground, and false if not
            enemyTurn = !Physics2D.OverlapCircle(groundCheck.position, 0.1f, Foreground);
        }
    }

    public void TakeDamage(int damage)
    {  
        health -= damage;

        if (health > 0)
        {
            enemyAnimator.SetTrigger("Hurt");
        }
        else
        {
            enemyAnimator.SetTrigger("Death");
            Destroy(gameObject, 1.4f);
        }
    }

    // Patrol Function to make character walk
    void Patrol()
    {
        // Velocity to move character in right direction
        enemyRB.velocity = new Vector2(PatrolSpeed * Time.fixedDeltaTime, enemyRB.velocity.y);

        if (enemyTurn || enemyCollider.IsTouchingLayers(Foreground))
        {
            // Flip character in left direction once end of platfrom reached or collider hits the wall
            Flip();
        }
    }

    // Flip Function
    public void Flip()
    {
        EnemyPatrol = false;
        transform.Rotate(0, 180, 0);
        PatrolSpeed *= -1;
        EnemyPatrol = true;
    }
}