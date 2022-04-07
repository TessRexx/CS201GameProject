using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockProjectileScript : MonoBehaviour
{
    [SerializeField] float dieTime = 5, damage;
    [SerializeField] GameObject dieEffect;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    IEnumerator CountdownTime()
    {
        yield return new WaitForSeconds(dieTime);

        Destroy(gameObject);
    }
}
