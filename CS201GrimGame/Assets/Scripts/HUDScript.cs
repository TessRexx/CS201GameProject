// THIS SCRIPT RELAYS INFO TO PLAYER SUCH AS HEALTH AND ITEMS TO BE COLLECTED

using UnityEngine;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour
{
    // Key References & Variables
    [SerializeField] KeyCollectibleScript keyCollectible;
    [SerializeField] public Image keyCollected;

    // Healthbar References & Variables
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] Image totalHealth;
    [SerializeField] Image currentHealth;
    int fillAmount = 3;

    // Start is called before the first frame update
    void Start()
    {
        // Setting full health bar on launch
        totalHealth.fillAmount = playerHealth.currentHealth / fillAmount;
        // Setting keys to 0 on launch
        keyCollected.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Updating health bar fill amount
        currentHealth.fillAmount = playerHealth.currentHealth / fillAmount;
    }
}
