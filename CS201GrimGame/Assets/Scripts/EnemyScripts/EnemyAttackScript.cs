using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackScript : MonoBehaviour
{
    // Attack Variables
    float cooldownTimer = 1.5f;
    [SerializeField] float range = 4;
    float distanceToPlayer;
    [SerializeField] Transform player, throwPosition;
    bool canAttack = true;
    [SerializeField] GameObject rockProjectile;

    // References
    [SerializeField]Animator enemyAnimator;
    EnemyScript enemyScript;

    // Start is called before the first frame update
    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        enemyScript = GameObject.FindObjectOfType(typeof(EnemyScript)) as EnemyScript;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculates distance between 2 game objects (player and enemy)
        distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if(distanceToPlayer <= range)
        {
            // if player is ahead of enemy while enemy faces left or if  player is behind enemy while enemy faces right then flip
            if (player.position.x > transform.position.x && transform.rotation.y < 0
                || player.position.x < transform.position.x && transform.rotation.y >= 0)
            {
                enemyScript.Flip();
            }

            enemyScript.EnemyPatrol = false;
            enemyScript.enemyRB.velocity = Vector2.zero;

            if (canAttack)
            {
                StartCoroutine(Attack());
            }           
        }
        else
        {
            enemyScript.EnemyPatrol = true;
        }

    }   

    IEnumerator Attack()
    {
        canAttack = false;
        yield return new WaitForSeconds(cooldownTimer);
        enemyAnimator.SetTrigger("Attack");
        Instantiate(rockProjectile, throwPosition.position, throwPosition.rotation);
        canAttack = true;
    }
}
