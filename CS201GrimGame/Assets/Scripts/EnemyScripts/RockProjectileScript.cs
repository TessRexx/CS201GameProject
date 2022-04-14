// THIS SCRIPT IS USED FOR THE ROCK PROJECTILE IN GAMR TO DAMAGE THE PLAYER

using System.Collections;
using UnityEngine;

public class RockProjectileScript : MonoBehaviour
{
    // References
    Rigidbody2D RockProjectileRB;
    PlayerHealth playerHealth;
    
    // Variables
    [SerializeField] float RockProjectileSpeed = 0.0f;
    [SerializeField] float projectileDamage;

    // Start is called before the first frame update
    void Start()
    {
        // Component References
        RockProjectileRB = GetComponent<Rigidbody2D>();
        RockProjectileRB.velocity = transform.right * RockProjectileSpeed * Time.deltaTime;
    }

    // Rock Collsion Method
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // When rock collides with player or environment, call destroy method
        StartCoroutine(DestroyRock());
    }

    // Trigger Damage Method
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If rock hits player, calls damage method from PlayerHealth script
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerHealth>().TakeDamage(projectileDamage);
        }
    }

    // Destroy Rock Object Method
    IEnumerator DestroyRock()
    {
        // After 1 second, the rock will be destroyed
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
