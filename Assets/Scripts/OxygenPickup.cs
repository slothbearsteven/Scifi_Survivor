using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenPickup : Interactable
{

    public override void Interact()
    {
        PlayerController.playerOxygen += 20;
        if (!gameObject.CompareTag("Dispenser"))
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
