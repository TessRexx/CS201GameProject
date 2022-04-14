// THIS SCRIPT CONTAINS PLAYER HEALTH, TAKING DAMAGE, DEATH AND GAME RESTART

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    // Health References & Variables
    Animator playerAnimator;
    [SerializeField] public float startingHealth;
    public float currentHealth { get; private set; }

    // Restart References & Variables
    Animator transitionAnimator;
    float restartTimer = 2;

    // Start is called before the first frame update
    void Start()
    {
        // Component References
        playerAnimator = GetComponent<Animator>();
        transitionAnimator = GetComponent<Animator>();

        // Setting to full health on launch
        currentHealth = startingHealth;
    }

    // Player Take Damage Method
    public void TakeDamage(float damageInflicted)
    {
        // Reduces health with safe guard to ensure doesn't go below 0 or above starting health
        currentHealth = Mathf.Clamp(currentHealth - damageInflicted, 0, startingHealth);
        playerAnimator.SetTrigger("Hurt");
        
        // If no health remaining, call die method
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    // Player Death Method
    void Die()
    {
        playerAnimator.SetTrigger("Death");
        // Disable movement once player dead
        GetComponent<PlayerBehaviourScript>().enabled = false;
        // Call level restart function
        StartCoroutine(Restart());
    }

    // Player Add Health Method
    public void AddHealth(float value)
    {
        // Adds to health when called in health collectible script
        currentHealth = Mathf.Clamp(currentHealth + value, 0, startingHealth);
    }

    // Level Restart Method
    IEnumerator Restart()
    {
        // Wait for 2 seconds and then fadeout
        yield return new WaitForSeconds(restartTimer);
        transitionAnimator.SetTrigger("Crossfade");
        // Returns name of current scene and loads it
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
