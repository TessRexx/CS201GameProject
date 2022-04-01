using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    Rigidbody2D enemyRB;
    [SerializeField] float movementSpeed = 2.0f;

    bool switchDirection;

    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        while (transform.position.x >= 16.3f)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            enemyRB.velocity = new Vector2(movementSpeed, 0);
        }

        while (transform.position.x > 19.6f)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            enemyRB.velocity = new Vector2(-movementSpeed, 0);
        }
    }
}