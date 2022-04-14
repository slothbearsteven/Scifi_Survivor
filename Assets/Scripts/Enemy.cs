using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update

    int enemyHealth = 20;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth <= 0) { Destroy(gameObject); }
    }

    void OnCollisionEnter2D(Collision2D col)
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            enemyHealth -= 5;
            Destroy(other.gameObject);
        }
    }
}
