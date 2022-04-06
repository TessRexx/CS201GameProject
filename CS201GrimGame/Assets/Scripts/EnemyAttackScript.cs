using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackScript : MonoBehaviour
{
    // Attack Variables
    float attackCooldown = 1;
    int damage = 1;
    float range = -3.5f;

    // Collider Parameters
    float colliderDistance = -0.25f;
    [SerializeField] BoxCollider2D boxCollider;

    // Player Layer
    [SerializeField] LayerMask playerLayer;
    float cooldownTimer = Mathf.Infinity;

    // References
    [SerializeField]Animator enemyAnimator;
    EnemyScript enemyPatrol;
    PlayerScript playerHealth;


    // Start is called before the first frame update
    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyScript>();
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer += Time.deltaTime;

        if(PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                // Reset timer to 0
                cooldownTimer = 0;
                enemyAnimator.SetTrigger("Attack");
            }
        }
    }   

    private bool PlayerInSight()
    {
        // Determine if player in enemy sight
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);

        if (hit.collider != null)
        {
            playerHealth = hit.transform.GetComponent<PlayerScript>();
        }

        // Return true when not null, return false when is null
        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

   void DamagePlayer()
    {
        // If player still in range, damage them
        if(PlayerInSight())
        {
            //playerHealth.TakeDamage(damage);
        }
    }
}
