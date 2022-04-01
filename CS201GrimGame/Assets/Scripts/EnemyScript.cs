using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    Rigidbody2D enemyRB;
    float movementSpeed = 0.7f;
    Vector3 positionX1 = new Vector3(16.3f, -4.46f, 0);
    Vector3 positionX2 = new Vector3(19.6f, -4.46f, 0);

    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        /*// If statement to move enemy right
        if (transform.position.x > 16.3f)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            enemyRB.velocity = new Vector2(movementSpeed, 0);
        }
        // If statement to move enemy left
        if (transform.position.x >= 19.6f)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            enemyRB.velocity = new Vector2(-movementSpeed, 0);
        }*/

        // Moves between each position but doesn't flip
        transform.position = Vector3.Lerp(positionX1, positionX2, (Mathf.PingPong(Time.time * movementSpeed, 1.0f)));

      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Environment"))
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

}