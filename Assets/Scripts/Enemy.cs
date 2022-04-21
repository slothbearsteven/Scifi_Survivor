using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update

    int enemyHealth = 20;

    public GameObject deathParticles;
    public GameObject taserElectricity;


    // Update is called once per frame
    void Update()
    {
        DeathHandler();
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
        if (other.gameObject.CompareTag("PlayerBullet") && gameObject.CompareTag("Enemy"))
        {


            enemyHealth -= 5;
            Destroy(other.gameObject);
        }

    }



}
