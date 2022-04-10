using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    [SerializeField] float spikeDamage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerHealth>().TakeDamage(spikeDamage);
        }
    }
}
