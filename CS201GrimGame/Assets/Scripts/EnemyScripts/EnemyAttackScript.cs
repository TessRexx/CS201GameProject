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
    public float cooldownTimer = 1;
    float distanceToPlayer;
    public bool canAttack = true;

    // Start is called before the first frame update
    void Start()
    {
        // Component References
        enemyAnimator = GetComponent<Animator>();
        enemyScript = GameObject.FindObjectOfType(typeof(EnemyBehaviourScript)) as EnemyBehaviourScript;

        // Set to true on launch
        canAttack = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculates distance between 2 game objects (enemy and player)
        distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // If player in range and view of enemy, call attack method, else continue patrolling 
        if (distanceToPlayer <= range)
        {
            Debug.Log("Player in range");
            if (player.position.x < transform.position.x && transform.rotation.y < 0
                || player.position.x > transform.position.x && transform.rotation.y >= 0)

            {
                Debug.Log("Player in view");
                if (canAttack)
                {
                    Debug.Log("can attack");
                    StartCoroutine(Attack());
                }
            }
        }
        else
        {
            Debug.Log("Player not in range");
            enemyScript.EnemyPatrol = true;
        }
    }

    // IEnumerator Enemy Attack Method
    IEnumerator Attack()
    {
        canAttack = false;
        yield return new WaitForSeconds(cooldownTimer);
        enemyAnimator.SetTrigger("Attack");
        Instantiate(rockProjectile, throwPosition.position, throwPosition.rotation);
        yield return new WaitForSeconds(cooldownTimer);
        canAttack = true;
    }
}
