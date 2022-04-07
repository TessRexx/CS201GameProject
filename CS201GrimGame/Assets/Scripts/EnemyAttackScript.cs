using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackScript : MonoBehaviour
{
    // Attack Variables
    float cooldownTimer = 2;
    int damage = 1;
    [SerializeField] float range = 3;
    [SerializeField] float throwSpeed = 2;
    float distanceToPlayer;
    [SerializeField] Transform player, shootPosition;
    bool canAttack = true;
    [SerializeField] GameObject rockProjectile;

    // References
    [SerializeField]Animator enemyAnimator;
    PlayerScript playerHealth;
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
        // Calculates distance between 2 game objects
        distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if(distanceToPlayer <= range)
        {
            if(player.position.x > transform.position.x && transform.localScale.x < 0 
                || player.position.x < transform.position.x && transform.localScale.x > 0)
            {
                enemyScript.Flip();
            }
            enemyScript.enemyPatrol = false;
            enemyScript.enemyRB.velocity = Vector2.zero;
            if (canAttack)
            {
                StartCoroutine(Attack());
            }           
        }
        else
        {
            enemyScript.enemyPatrol = true;
        }

    }   

    IEnumerator Attack()
    {
        canAttack = false;
        yield return new WaitForSeconds(cooldownTimer);
        GameObject newRock = Instantiate(rockProjectile, shootPosition.position, Quaternion.identity);
        newRock.GetComponent<Rigidbody2D>().velocity = new Vector2(throwSpeed * enemyScript.patrolSpeed * Time.fixedDeltaTime, 0);
        enemyAnimator.SetTrigger("Attack");
        canAttack = true;
    }


   void DamagePlayer()
    {

    }
}
