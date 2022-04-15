// THIS SCRIPT IS USED FOR PLAYER MELEE ATTACKS

using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // References
    [SerializeField] Transform AttackPosition;
    [SerializeField] LayerMask defineEnemies;
    [SerializeField] Animator playerAnimator;
    // Variables
    [SerializeField] float attackRange;
    [SerializeField] int damage;

    // Update is called once per frame
    void Update()
    {
        // If user left clicks, call Attack method
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
    }

    // Player Attack Method
    private void Attack()
    {
        // Attack animation trigger
        playerAnimator.SetTrigger("Attack");
        FindObjectOfType<AudioManager>().PlaySound("PlayerAttack"); // Trigger Sound

        // Define attack range
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(AttackPosition.position, attackRange, defineEnemies);
        // If player lands an attack on enemy, calls damage function from enemy behaviour script
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<EnemyBehaviourScript>().TakeDamage(damage);
        }
    }

    // Used to visualize attack range & position
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(AttackPosition.position, attackRange);
    }
}