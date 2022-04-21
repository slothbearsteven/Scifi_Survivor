using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityButton : Interactable
{
    public static bool securityIsActive;

    public override void Interact()
    {
        if (securityIsActive)
        {
            securityIsActive = false;
        }
        if (!securityIsActive)
        {
            securityIsActive = true;
        }
    }
    // Start is called before the first frame update
    void Awake()
    {
        securityIsActive = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
