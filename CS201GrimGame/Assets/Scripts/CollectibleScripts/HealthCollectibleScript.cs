using UnityEngine;

public class HealthCollectibleScript : MonoBehaviour
{
    // Variables & References
    [SerializeField] float healthValue;
    [SerializeField] PlayerHealth playerHealth;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Checking is player is touching the object and health isn't already full
        if (collision.tag == "Player" && playerHealth.currentHealth != playerHealth.startingHealth)
        {
            // Add corresponding value to health bar
            collision.GetComponent<PlayerHealth>().AddHealth(healthValue);
            // Set object to inactive so it can't be used again
            gameObject.SetActive(false);
        }
    }
}
