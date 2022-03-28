using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{


    public GameObject weaponProjectile;
    public GameObject bulletSpawner;
    public static Quaternion bulletSpawnRotation;
    public static GameObject bulletToFire;
    public static Vector3 bulletSpawnPoint;
    private int clipCapacity;
    private float reloadSpeed;
    // Start is called before the first frame update
    void Awake()
    {
        bulletToFire = weaponProjectile;
    }


    // Update is called once per frame
    void Update()
    {
        bulletSpawnPoint = bulletSpawner.transform.position;
        bulletSpawnRotation = transform.rotation;

        WeaponMovement();
    }

    private void WeaponMovement()
    {
        //rotates weapon towards the mouse
        Vector3 mouseDifference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        mouseDifference.Normalize();
        float roatationZ = (Mathf.Atan2(mouseDifference.y, mouseDifference.x) * Mathf.Rad2Deg) - 90f;


        transform.rotation = Quaternion.Euler(0f, 0f, roatationZ);
    }

    public static void WeaponAttack()
    {


        Instantiate(bulletToFire, bulletSpawnPoint, bulletSpawnRotation);
    }
}
