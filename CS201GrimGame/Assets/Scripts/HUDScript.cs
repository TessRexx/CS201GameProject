using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI KeyText;
    [SerializeField] PlayerScript player;

    // Update is called once per frame
    void Update()
    {
        // Takes variable for player and adds to HUD Text
        KeyText.text = player.KeyCollected.ToString();
    }
}
