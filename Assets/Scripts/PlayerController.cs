using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using Color = UnityEngine.Color;

public class PlayerController : MonoBehaviour
{
    public static bool inShip;
    public GameObject interactionPrompt;
    public GameObject reloadingPrompt;
    public GameObject torpedoObject;
    private float shipSpeed = 5;
    public static int shipLife;
    private float shipTurnSpeed = -0.5f;
    public static int torpedoCount;
    private Vector2 boxSize = new Vector2(0.1f, 1f);
    private Rigidbody2D shipRB;
    public static float playerHealth = 100;
    public static float playerOxygen;
    // public static List<GameObject> inventory;
    private float playerSpeed = 10;
    // Start is called before the first frame update

    private SpriteRenderer playerRenderer;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameOver == false)
        {
            PlayerMovement();
            PlayerAttack();
            OxygenAndHealth();
            if (Input.GetKeyDown(KeyCode.E)) { CheckInteraction(); }
        }
    }

    void Awake()
    {
        playerRenderer = GetComponent<SpriteRenderer>();
        playerOxygen = 100;
        if (SceneManager.GetActiveScene().name == "Space")
        {
            inShip = true;
            shipRB = GetComponent<Rigidbody2D>();
        }
    }

    void PlayerMovement()
    {
        if (inShip)
        {
            //  Ship will be able to only thrust forward, having the player rely on rotating the ship to get where they need to go
            //Use vector force to create the movement, to add a sense of being floaty/ in space
            float forwardInput = Input.GetAxis("Vertical");
            float horizontalInput = Input.GetAxis("Horizontal");
            shipRB.AddForce(transform.up * shipSpeed * forwardInput);
            transform.Rotate(Vector3.forward, horizontalInput * shipTurnSpeed);
        }
        else
        {
            // player moves on the global axis, not their local axis. Use transform.position with key input to create a feeling of movement control in the environment
            //Player will rotate towards the mouse position
            Vector3 mouseDifference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            mouseDifference.Normalize();
            float roatationZ = (Mathf.Atan2(mouseDifference.y, mouseDifference.x) * Mathf.Rad2Deg) - 90f;
            float verticalInput = Input.GetAxis("Vertical");
            float horizontalIput = Input.GetAxis("Horizontal");

            transform.rotation = Quaternion.Euler(0f, 0f, roatationZ);
            transform.Translate(Vector3.up * playerSpeed * verticalInput * Time.deltaTime, Space.World);
            transform.Translate(Vector3.right * playerSpeed * horizontalIput * Time.deltaTime, Space.World);

            if (verticalInput > 0 || horizontalIput > 0 || verticalInput < 0 || horizontalIput < 0)
            {
                playerOxygen -= Time.deltaTime;



            }
        }
    }
    void OxygenAndHealth()
    {
        if (playerOxygen <= 0) { playerOxygen = 0; }
        if (playerOxygen == 0)
        {
            playerHealth -= Time.deltaTime;
        }
        if (playerHealth <= 0)
        {
            playerHealth = 0;
        }
        if (playerHealth > 100)
        {
            playerHealth = 100;
        }
        if (playerOxygen > 100)
        {
            playerOxygen = 100;
        }


        if (playerHealth == 0)
        {
            GameManager.gameOver = true;
        }
    }
    void PlayerAttack()
    {
        if (inShip)
        {
            if (Input.GetKeyDown(KeyCode.Space) && torpedoCount > 0)
            {
                torpedoCount--;
                Instantiate(torpedoObject, transform.position, transform.rotation);
            }
        }
        else
        {

            if (Input.GetMouseButtonDown(0) && Weapon.currentClipCount > 0)
            {
                Weapon.WeaponAttack();
            }
            else if (Input.GetMouseButtonDown(0) && Weapon.currentClipCount == 0)
            {
                StartCoroutine(ReloadRoutine());
            }
            //when player clicks the mouse, calls to the weapon script to trigger the attack
        }

    }

    public void OpenInteractableIcon()
    {
        interactionPrompt.SetActive(true);
    }
    public void CloseInteractableIcon()
    {
        interactionPrompt.SetActive(false);
    }

    private void CheckInteraction()
    {
        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, boxSize, 0, Vector2.zero);

        if (hits.Length > 0)
        {
            foreach (RaycastHit2D rc in hits)
            {
                if (rc.transform.GetComponent<Interactable>())
                {
                    rc.transform.GetComponent<Interactable>().Interact();
                    return;
                }
            }
        }
    }

    IEnumerator ReloadRoutine()
    {

        reloadingPrompt.SetActive(true);

        yield return new WaitForSeconds(Weapon.reloadSpeed);

        if (Weapon.currentClipCount == 0)
        {

            Weapon.currentClipCount = Weapon.clipCapacity;
            reloadingPrompt.SetActive(false);
        }

    }

    public static void PlayerDamaged(int DOT)
    {
        playerHealth -= DOT * Time.deltaTime;
    }


}
