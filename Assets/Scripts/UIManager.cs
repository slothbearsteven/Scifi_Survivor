using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text oxygen;
    public Text health;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float currentO2 = Mathf.Round(PlayerController.playerOxygen);
        float currentHealth = Mathf.Round(PlayerController.playerHealth);
        oxygen.text = $"O2:{currentO2}";
        health.text = $"Health:{currentHealth}";
    }
}
