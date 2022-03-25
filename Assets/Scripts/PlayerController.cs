using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private bool inShip;
    public GameObject interactionPrompt;
    public GameObject torpedoObject;
    private float shipSpeed = 5;
    public static int shipLife;
    private float shipTurnSpeed = -0.5f;
    public static int torpedoCount;
    private Vector2 boxSize = new Vector2(0.1f, 1f);
    private Rigidbody2D shipRB;
    public static int playerHealth;
    public static int playerOxygen;
    public static List<GameObject> inventory;
    private float playerSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        if (Input.GetKeyDown(KeyCode.E)) { CheckInteraction(); }
    }

    void Awake()
    {
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

            if (Input.GetMouseButtonDown(0))
            {


            }
            //when player clicks the mouse, makes the correct attack depending on item tag: melee or ranged. Attack with be in the dirction towards the mouse's position on the screen
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
}
