using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEffects : MonoBehaviour
{

    int secondsToLast = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LifeSpanRoutine()
    {
        yield return new WaitForSeconds(secondsToLast);
        Destroy(gameObject);
    }
}
