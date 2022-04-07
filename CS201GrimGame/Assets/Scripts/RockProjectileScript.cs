using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockProjectileScript : MonoBehaviour
{
    Rigidbody2D RockProjectileRB;
    [SerializeField] float RockProjectileSpeed = 4.0f;

    [SerializeField] float damage;

    void Start()
    {       
        RockProjectileRB = GetComponent<Rigidbody2D>();
        RockProjectileRB.velocity = transform.right * RockProjectileSpeed * Time.deltaTime;
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject); // Destroy if player hit
        }
        Destroy(gameObject); // Destroy projectile
    }*/
}
