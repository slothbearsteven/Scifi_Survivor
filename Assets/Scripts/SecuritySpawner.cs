using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecuritySpawner : MonoBehaviour
{
    public GameObject securityDronePrefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SecuritySpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SecuritySpawnRoutine()
    {
        if (SecurityButton.securityIsActive)
        {
            yield return new WaitForSeconds(5);
            Instantiate(securityDronePrefab, transform.position, transform.rotation);
        }

    }
}
