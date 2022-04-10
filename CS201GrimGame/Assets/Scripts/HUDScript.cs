using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDScript : MonoBehaviour
{
    // Key Variables
    [SerializeField] TextMeshProUGUI KeyText;
    [SerializeField] PlayerScript player;

    // Healthbar Variables
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] Image totalHealth;
    [SerializeField] Image currentHealth;
    int fillAmount = 3;

    void Start()
    {
        // Setting full health bar when starting game
        totalHealth.fillAmount = playerHealth.currentHealth / fillAmount;
    }

    // Update is called once per frame
    void Update()
    {
        // Takes variable for player and adds to HUD Text
        KeyText.text = player.KeyCollected.ToString();

        // Updating health bar fill amount
        currentHealth.fillAmount = playerHealth.currentHealth / fillAmount;
    }
}
