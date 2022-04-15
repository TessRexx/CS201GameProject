// THIS SCRIPT IS USED FOR ENEMY RANGED ATTACKS

using System.Collections;
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
    public float cooldownTimer = 1.5f;
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
                StartCoroutine(Attack());
            }
        }
        else
        {
            // Enemy will keep patrolling
            enemyScript.EnemyPatrol = true;
        }
    }

    // IEnumerator Enemy Attack Method
    IEnumerator Attack()
    {
        canAttack = false;
        yield return new WaitForSeconds(cooldownTimer);
        enemyScript.enemyRB.velocity = Vector2.zero;
        enemyAnimator.SetTrigger("Attack");
        Instantiate(rockProjectile, throwPosition.position, throwPosition.rotation);
        yield return new WaitForSeconds(cooldownTimer);
        canAttack = true;
    }
}
