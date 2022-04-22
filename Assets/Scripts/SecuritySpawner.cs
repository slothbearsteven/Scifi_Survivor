using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecuritySpawner : MonoBehaviour
{
    public GameObject securityDronePrefab;

    float respawnRate = 5;
    float timePassed = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (SecurityButton.securityIsActive)
        {
            timePassed += Time.deltaTime;
            if (timePassed >= respawnRate)
            {
                timePassed = 0;
                Instantiate(securityDronePrefab, transform.position, transform.rotation);
            }



        }

    }


}
