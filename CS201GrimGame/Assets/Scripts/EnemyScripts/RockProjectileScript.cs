using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockProjectileScript : MonoBehaviour
{
    Rigidbody2D RockProjectileRB;
    [SerializeField] float RockProjectileSpeed = 0.0f;

    [SerializeField] float projectileDamage;

    PlayerHealth playerHealth;

    void Start()
    {       
        RockProjectileRB = GetComponent<Rigidbody2D>();
        RockProjectileRB.velocity = transform.right * RockProjectileSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(DestroyRock());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerHealth>().TakeDamage(projectileDamage);
        }
    }

    IEnumerator DestroyRock()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
