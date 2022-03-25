using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public abstract class Interactable : MonoBehaviour
{
    // Start is called before the first frame update
    private void Reset()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }
    public abstract void Interact();


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("trigger enter");
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().OpenInteractableIcon();
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("trigger exit");
        if (other.CompareTag("Player"))
        {

            other.GetComponent<PlayerController>().CloseInteractableIcon();
        }
    }
}
