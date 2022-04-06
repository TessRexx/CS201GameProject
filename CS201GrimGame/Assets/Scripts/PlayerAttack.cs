using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    float attackCooldown;
    float startAttackCooldown = 0.3f;

    [SerializeField] Transform AttackPosition;
    [SerializeField] LayerMask defineEnemies;
    [SerializeField]  Animator playerAnimator;
    [SerializeField] float attackRange;
    int damage = 1;

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    private void Attack()
    {
        if (attackCooldown <= 0)
        {
            // Able to attack
            if (Input.GetButtonDown("Fire1"))
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
        }
        else
        {
            attackCooldown -= Time.deltaTime;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(AttackPosition.position, attackRange);
    }
}