using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door_SceneChange : Interactable
{
    public int sceneDestination;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void Interact()
    {
        SceneManager.LoadScene(sceneDestination);
    }



}
