using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    float timeBetweenAttack;
    [SerializeField] float startTimeBetweenAttack;

    [SerializeField] Transform AttackPosition;
    [SerializeField] LayerMask defineEnemies;
    [SerializeField] float attackRange;
    Animator playerAnimator;
    [SerializeField] int damage;

    // Update is called once per frame
    void Update()
    {
        if (timeBetweenAttack <= 0)
        {
            // Able to attack
            if (Input.GetButtonDown("Fire1"))
            {
                playerAnimator.SetTrigger("Attack");

                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(AttackPosition.position, attackRange, defineEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<EnemyScript>().TakeDamage(damage);
                }

                timeBetweenAttack = startTimeBetweenAttack;
            }
            else
            {
                timeBetweenAttack -= Time.deltaTime;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(AttackPosition.position, attackRange);
    }
}
