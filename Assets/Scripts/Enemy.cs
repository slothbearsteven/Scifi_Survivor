using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update

    int enemyHealth = 40;
    bool isAttacking = false;
    public GameObject deathParticles;
    public GameObject taserElectricity;
    void Awake()
    {
        StartCoroutine(TaserEffectRoutine());
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
            //currently with the two colliders, the enemy is taking double the damage displayed, as the bullet triggers both on impact. doubled health in the meantime to counter this. Later on will make the taser/attack a seperate script for convenience

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

    IEnumerator TaserEffectRoutine()
    {
        while (!GameManager.gameOver)
        {
            taserElectricity.SetActive(true);
            yield return new WaitForSeconds(.1f);
            taserElectricity.SetActive(false);
            yield return new WaitForSeconds(.1f);
        }
    }
}
