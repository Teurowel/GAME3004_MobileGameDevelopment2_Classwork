using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    // Control Properties
    [Header("Controls")]
    public Joystick leftStick;

    // Movement Properties
    [Header("Movement")] 
    public float maxSpeed = 10.0f;
    public float gravity = -30.0f;
    public float jumpHeight = 3.0f;
    public Vector3 velocity;

    // Ground Check Properties
    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundRadius = 0.5f;
    public LayerMask groundMask;
    public bool isGrounded;

    [Header("Character Controller")] 
    public CharacterController controller;

    [Header("MiniMap")] 
    public GameObject miniMapBorder;

    [Header("Selection Properties")] 
    public Transform playerCamera;
    public Material selectable;

    [Header("Control Panel")]
    public GameObject controlPanel;

    [Header("Player Attributes")] 
    public HealthBar healthBar;
    [Range(0, 100)]
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        miniMapBorder.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out hit, 200.0f))
        {
            if (hit.transform.gameObject.CompareTag("Selectable"))
            {
                hit.transform.gameObject.GetComponent<MeshRenderer>().material = selectable;
            }
           

        }


        isGrounded = Physics.CheckSphere(groundCheck.position, groundRadius, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2.0f;
        }

        // movement
        //float x = Input.GetAxis("Horizontal");
        //float z = Input.GetAxis("Vertical");

        float x = leftStick.Horizontal;
        float z = leftStick.Vertical;

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * maxSpeed * Time.deltaTime);

        // jumping
        if (Input.GetButton("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravity);
        }

        // gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // Toggle MiniMap
        if (Input.GetKeyDown(KeyCode.M))
        {
            miniMapBorder.SetActive(!miniMapBorder.activeInHierarchy);
        }

        healthBar.SetHealth(health);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
        Gizmos.DrawLine(playerCamera.position, playerCamera.forward * 100.0f);
    }

    public void onYButtonPressed()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravity);
    }

    public void onBButtonPressed()
    {
        miniMapBorder.SetActive(!miniMapBorder.activeInHierarchy);
    }

    public void onIButtonPressed()
    {
        controlPanel.SetActive(!controlPanel.activeInHierarchy);
    }
}
