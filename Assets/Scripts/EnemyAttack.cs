using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject taserElectricity;
    public int damageToPlayer;
    bool inRange = false;
    void Awake()
    {
        StartCoroutine(TaserEffectRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange)
        {
            PlayerController.PlayerDamaged(damageToPlayer);
        }
    }

    IEnumerator TaserEffectRoutine()
    {
        while (!GameManager.gameOver)
        {
            taserElectricity.SetActive(true);
            yield return new WaitForSeconds(.1f);
            taserElectricity.SetActive(false);
            yield return new WaitForSeconds(.1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inRange = false;
        }
    }
}
