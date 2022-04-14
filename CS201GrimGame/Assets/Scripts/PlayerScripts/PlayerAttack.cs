using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    float attackCooldown;
    float startAttackCooldown = 0.3f;

    [SerializeField] Transform AttackPosition;
    [SerializeField] LayerMask defineEnemies;
    [SerializeField] Animator playerAnimator;
    [SerializeField] float attackRange;
    [SerializeField] int damage;

    // Update is called once per frame
    void Update()
    {
        // Able to attack
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
    }

    private void Attack()
    {
        // Attack animation trigger
        playerAnimator.SetTrigger("Attack");

        // Damage to enemy
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(AttackPosition.position, attackRange, defineEnemies);
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<EnemyScript>().TakeDamage(damage);
        }
        attackCooldown = startAttackCooldown;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(AttackPosition.position, attackRange);
    }
}