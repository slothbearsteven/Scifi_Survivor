using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullets : Projectile
{
    private float speed = 40;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ProjectileMovement(speed);
    }

}
