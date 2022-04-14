// THIS SCRIPT IS USED FOR COLLECTING KEYS IN GAME NEED FOR BOSS LEVEL ACCESS

using UnityEngine;

public class KeyCollectibleScript : MonoBehaviour
{
    // References & Variables
    [SerializeField] HUDScript hud;
    [HideInInspector] public int KeyAmount = 0;

    // Collection Method
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If Key Collected
        if (collision.gameObject.CompareTag("Player"))
        {
            // Add to key count
            KeyAmount++;
            // Add corresponding value to health bar
            hud.keyCollected.fillAmount = 1;
            // Set object to inactive so it can't be taken again
            gameObject.SetActive(false);
        }
    }
}
