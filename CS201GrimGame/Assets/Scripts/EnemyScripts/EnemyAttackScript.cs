// THIS SCRIPT IS USED FOR ENEMY RANGED ATTACKS

using UnityEngine;

public class EnemyAttackScript : MonoBehaviour
{
    // References
    [SerializeField] Animator enemyAnimator;
    EnemyBehaviourScript enemyScript;
    [SerializeField] GameObject rockProjectile;
    [SerializeField] Transform player, throwPosition;

    // Variables
    [SerializeField] float range = 4;
    public float cooldownTimer = 0f;
    public float attackRate = 1.5f;
    float distanceToPlayer;
    public bool canAttack = true;

    // Start is called before the first frame update
    void Start()
    {
        // Component References
        enemyAnimator = GetComponent<Animator>();
        enemyScript = GameObject.FindObjectOfType(typeof(EnemyBehaviourScript)) as EnemyBehaviourScript;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculates distance between 2 game objects (player and enemy)
        distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // if player is ahead of enemy while enemy faces left or if  player is behind enemy while enemy faces right then flip
        if (distanceToPlayer <= range && player.position.x < transform.position.x && transform.rotation.y < 0
            || distanceToPlayer <= range && player.position.x > transform.position.x && transform.rotation.y >= 0)
        {
            if (canAttack)
            {
                // Stop enemy from moving
                enemyScript.EnemyPatrol = false;        
                // Call attack method
                Attack();
            }
        }
        else
        {
            // Enemy will keep patrolling
            enemyScript.EnemyPatrol = true;
        }
    }

    // Enemy Attack Method
    void Attack()
    {
        if(Time.time >= cooldownTimer)
        {
            canAttack = false;
            enemyScript.enemyRB.velocity = Vector2.zero;
            enemyAnimator.SetTrigger("Attack");
            Instantiate(rockProjectile, throwPosition.position, throwPosition.rotation);
            cooldownTimer = Time.time + attackRate;
            canAttack = true;
        }
    }
}
