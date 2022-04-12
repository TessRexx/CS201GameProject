using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    // Variables & References
    [SerializeField] public float startingHealth;
    public float currentHealth { get; private set; }
    Animator playerAnimator, transitionAnimator;
    float restartTimer = 2;

    void Start()
    {
        currentHealth = startingHealth;
        playerAnimator = GetComponent<Animator>();
        transitionAnimator = GetComponent<Animator>();
    }

    // Function to effect health based on damage
    public void TakeDamage(float damageInflicted)
    {
        // Safe guard to ensure doesn't go below 0 or above starting health
        currentHealth = Mathf.Clamp(currentHealth - damageInflicted, 0, startingHealth);

        // If player still has health
        if(currentHealth > 0)
        {
            playerAnimator.SetTrigger("Hurt");
        }
        else
        {
            playerAnimator.SetTrigger("Death");
            // Disable movement once player dead
            GetComponent<PlayerScript>().enabled = false;
            StartCoroutine(Restart());
            
        }
    }

    public void AddHealth(float value)
    {
        currentHealth = Mathf.Clamp(currentHealth + value, 0, startingHealth);
    }

    // Restart function triggered when player loses all health
    IEnumerator Restart()
    {
        yield return new WaitForSeconds(restartTimer);
        transitionAnimator.SetTrigger("Crossfade");
        // Returns name of current scene and loads it
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
