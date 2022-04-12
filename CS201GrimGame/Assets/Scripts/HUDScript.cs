using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDScript : MonoBehaviour
{
    // Key Variables
    [SerializeField] KeyCollectibleScript keyCollectible;
    [SerializeField] public Image keyCollected;

    // Healthbar Variables
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] Image totalHealth;
    [SerializeField] Image currentHealth;
    int fillAmount = 3;

    void Start()
    {
        // Setting full health bar when starting game
        totalHealth.fillAmount = playerHealth.currentHealth / fillAmount;

        keyCollected.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Updating health bar fill amount
        currentHealth.fillAmount = playerHealth.currentHealth / fillAmount;
    }
}
