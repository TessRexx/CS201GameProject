// THIS SCRIPT IS FOR SPIKE TRAPS TO DAMAGE PLAYER
using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    // Variables
    [SerializeField] float spikeDamage;

    // Trigger Damage Method
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If player hits spikes, calls damage method from PlayerHealth script
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerHealth>().TakeDamage(spikeDamage);
        }
    }
}
