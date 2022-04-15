// THIS SCRIPT CONTAINS ENEMY MOVEMENT FOR PATROLLING, TAKING DAMAGE, AND DYING

using UnityEngine;

public class EnemyBehaviourScript : MonoBehaviour
{
    // References
    public Rigidbody2D enemyRB { get; private set; }
    [SerializeField] Animator enemyAnimator;
    [SerializeField] EnemyAttackScript attack;

    // Health Variables
    [SerializeField] int health;

    // Patrol Variables
    public bool EnemyPatrol;
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

        // Set true on launch
        EnemyPatrol = true;
    }

    // Update is called once per frame
    void Update()
    {
        // If EnemyPatrol is true, call patrol method
        if (EnemyPatrol)
        {
            enemyAnimator.SetBool("Walk", true);
            Patrol();
            // Returns true if groundCheck layer contains ground, and false if not
            enemyTurn = !Physics2D.OverlapCircle(groundCheck.position, 0.1f, Foreground);
        }
    }

    // Enemy Take Damage Method
    public void TakeDamage(int damage)
    {
        // Stops from attacking when taking damage
        attack.canAttack = false;
        // Reduces health
        health -= damage;
        enemyAnimator.SetTrigger("Hurt");
        FindObjectOfType<AudioManager>().PlaySound("EnemyHurt"); // Trigger Sound
        // If no health left, call death method
        if (health <= 0)
        {
            Die();
        }
    }

    // Enemy Death Method
    void Die()
    {
        enemyAnimator.SetTrigger("Death");
        // Stops enemy from moving and attacking when dead
        EnemyPatrol = false;
        GetComponent<EnemyAttackScript>().enabled = false;
        // Destroys enemy object
        Destroy(gameObject, 1.2f);
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