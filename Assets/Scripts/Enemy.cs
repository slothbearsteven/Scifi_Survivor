using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update

    int enemyHealth = 20;
    bool isAttacking = false;
    public GameObject deathParticles;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DeathHandler();
        if (isAttacking)
        {
            PlayerController.PlayerDamaged();
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {

    }
    void DeathHandler()
    {
        if (enemyHealth <= 0)
        {
            Instantiate(deathParticles, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            enemyHealth -= 5;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Player"))
        {
            isAttacking = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isAttacking = false;
        }
    }
}
