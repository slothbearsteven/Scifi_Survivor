using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject impactParticles;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ProjectileMovement(float speed)
    {
        transform.Translate(Vector2.up * Time.deltaTime * speed);
    }


    void OnCollisionEnter2D(Collision2D col)
    {

        Instantiate(impactParticles, transform.position, transform.rotation);
        Destroy(gameObject);
    }

}

