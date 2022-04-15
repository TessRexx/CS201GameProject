// THIS SCRIPT CONTAINS ENEMY MOVEMENT FOR PATROLLING, TAKING DAMAGE, AND DYING

using System.Collections;
using UnityEngine;

public class EnemyBehaviourScript : MonoBehaviour
{
    // References
    public Rigidbody2D enemyRB { get; private set; }
    [SerializeField] Animator enemyAnimator;
    EnemyAttackScript enemyAttack;

    // Health Variables
    [SerializeField] int health;

    // Patrol Variables
    public bool EnemyPatrol = true;
    public float PatrolSpeed;

    // Flip Variables & References
    bool enemyTurn;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask Foreground;
    [SerializeField] Collider2D enemyCollider;

    // Start is called before the first frame update
    void Start()
    {
        // Component References
        enemyRB = GetComponent<Rigidbody2D>();
        enemyAnimator = GetComponent<Animator>();
        enemyAttack = GetComponent<EnemyAttackScript>();
    }

    // Update is called once per frame
    void Update()
    {
        // If EnemyPatrol is true, call patrol method
        if (EnemyPatrol)
        {
            enemyAnimator.SetBool("Walk", true);
            Patrol();
        }
    }

    private void FixedUpdate()
    {
        // if statement while enemy is moving
        if (EnemyPatrol)
        {
            // Returns true if groundCheck layer contains ground, and false if not
            enemyTurn = !Physics2D.OverlapCircle(groundCheck.position, 0.1f, Foreground);
        }
    }

    // Enemy Take Damage Method
    public void TakeDamage(int damage)
    {
        // Stops from attacking when taking damage
        enemyAttack.canAttack = false;
        // Reduces health
        health -= damage;
        enemyAnimator.SetTrigger("Hurt");
        FindObjectOfType<AudioManager>().PlaySound("EnemyHurt"); // Trigger Sound
        // If no health left, call death method
        if (health <= 0)
        {
            Die();
        }
        else
        {
            enemyAttack.canAttack = true;
        }
    }

    // Enemy Death Method
    void Die()
    {
        enemyAnimator.SetTrigger("Death");
        // Stops enemy from moving and attacking when dead
        enemyRB.velocity = Vector2.zero;
        EnemyPatrol = false;
        // Destroys enemy object
        StartCoroutine(DestroyEnemy());
    }

    // Destroy Rock Object Method
    IEnumerator DestroyEnemy()
    {
        // After 1 second, the enemy will be destroyed
        yield return new WaitForSeconds(1.2f);
        gameObject.SetActive(false);
    }

    // Enemy Patrol Method
    void Patrol()
    {
        // Velocity to move character in right direction
        enemyRB.velocity = new Vector2(PatrolSpeed * Time.fixedDeltaTime, enemyRB.velocity.y);

        // If enemy hits wall or end of platform, flip to face opposite direction
        if (enemyTurn || enemyCollider.IsTouchingLayers(Foreground))
        {
            Flip();
        }
    }

    // Enemy Flip Method
    public void Flip()
    {
        EnemyPatrol = false;
        // Rotates enemy object to face opposite direction
        transform.Rotate(0, 180, 0);
        PatrolSpeed *= -1;
        EnemyPatrol = true;
    }
}