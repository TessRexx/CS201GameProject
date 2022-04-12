using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollectibleScript : MonoBehaviour
{

    // Public to access it from the HUDScript class
    [HideInInspector] public int KeyAmount = 0;
    [SerializeField] HUDScript hud;


    // Colection Method
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
