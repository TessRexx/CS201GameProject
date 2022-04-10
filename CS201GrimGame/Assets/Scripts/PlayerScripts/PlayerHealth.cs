using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float startingHealth;
    public float currentHealth { get; private set; }
    Animator playerAnimator;

    void Start()
    {
        currentHealth = startingHealth;
        playerAnimator = GetComponent<Animator>();
    }

    public void TakeDamage(float damageInflicted)
{
        // Safe guard to ensure doesn't go below 0 or above starting health
        currentHealth = Mathf.Clamp(currentHealth - damageInflicted, 0, startingHealth);

        if(currentHealth > 0)
        {
            playerAnimator.SetTrigger("Hurt");
        }
        else
        {
            playerAnimator.SetTrigger("Death");
            // Disable movement once player dead
            GetComponent<PlayerScript>().enabled = false;
        }
    }
}
