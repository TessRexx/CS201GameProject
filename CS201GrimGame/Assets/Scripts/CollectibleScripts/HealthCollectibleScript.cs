// THIS SCRIPT IS USED FOR THE HEART AND APPLE COLLECTIBLES IN GAME TO RESTORE THE PLAYERS HEALTH

using UnityEngine;


public class HealthCollectibleScript : MonoBehaviour
{
    // References & Variables
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] float healthValue;

    // Collect Health on Collision Method
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Checking is player is touching the object and health isn't already full
        if (collision.tag == "Player" && playerHealth.currentHealth != playerHealth.startingHealth)
        {
            // Add corresponding value to health bar
            collision.GetComponent<PlayerHealth>().AddHealth(healthValue);
            FindObjectOfType<AudioManager>().PlaySound("HealthCollected"); // Trigger Sound
            // Set object to inactive so it can't be used again
            gameObject.SetActive(false);
        }
    }
}
