using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class Interactable : MonoBehaviour
{
    // Start is called before the first frame update

    public abstract void Interact();


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger enter");
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().OpenInteractableIcon();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("trigger exit");
        if (other.CompareTag("Player"))
        {

            other.GetComponent<PlayerController>().CloseInteractableIcon();
        }
    }
}
