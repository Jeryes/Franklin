using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent( typeof(CharacterController) )]
public class PlayerController : MonoBehaviour
{
    // Variables
    public float speed = 5.0f;              // Movement speed
    public float rotationSpeed = 2.0f;      // Rotation speed
    public float gravity = -9.81f;          // Gravity acceleration
    public float jumpHeight = 2.0f;         // How high the character can jump
    private Vector3 velocity;               // To track movement velocity
    private bool isGrounded;                // To check if the player is on the ground
    private CharacterController controller; // A reference for the CharacterController component
    public GameObject playerBody;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        playerBody = GameObject.Find("Player/PlayerBody");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Ground check - make sure the character is on the ground
        isGrounded = controller.isGrounded;

        // Input handling
        float horizontal = Input.GetAxis("Horizontal");  // Get input for left/right
        float vertical = Input.GetAxis("Vertical");      // Get input for forward/backward

        // Combine into movement vector (X and Z axis)
        Vector3 moveDirection = new Vector3(horizontal, 0, vertical);
        
        // Normalize vector to ensure consistent speed in all directions
        if (moveDirection.magnitude > 1)
        {
            moveDirection.Normalize();
        }

        // Apply movement
        controller.Move(moveDirection * speed * Time.deltaTime);

        // Gravity handling
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2.0f;   // Reset Y velocity when on the ground
        }

        // Jump handling
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);  // Jump calculation
        }

        // Apply gravity to velocity
        velocity.y += gravity * Time.deltaTime;

        if (moveDirection != Vector3.zero) {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            playerBody.transform.rotation = Quaternion.RotateTowards(playerBody.transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        // Move the character based on velocity (gravity affects the Y-axis)
        controller.Move(velocity * Time.deltaTime);
    }
}
