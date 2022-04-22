using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityButton : Interactable
{
    private int triggerCount;
    public static bool securityIsActive;
    public GameObject alarmLight;

    public override void Interact()
    {
        triggerCount++;
        if (triggerCount == 3) triggerCount = 1;
        if (triggerCount % 2 == 0)
        {
            securityIsActive = false;
        }
        else { securityIsActive = true; }
    }
    // Start is called before the first frame update
    void Awake()
    {
        securityIsActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (securityIsActive)
        {
            alarmLight.SetActive(true);

        }
        else { alarmLight.SetActive(false); }
    }
}
