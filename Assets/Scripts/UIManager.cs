using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text oxygen;
    public Text health;
    public Text ammo;

    public GameObject gameOverDisplay;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.gameOver && !PlayerController.inShip)
        {
            float currentO2 = Mathf.Round(PlayerController.playerOxygen);
            float currentHealth = Mathf.Round(PlayerController.playerHealth);
            float currentAmmo = Mathf.Round(Weapon.currentClipCount);
            oxygen.text = $"O2:{currentO2}";
            health.text = $"Health:{currentHealth}";
            ammo.text = $"Rifle:{currentAmmo} / {Weapon.clipCapacity}";
        }

        if (GameManager.gameOver)
        {
            gameOverDisplay.SetActive(true);
        }
    }
}
