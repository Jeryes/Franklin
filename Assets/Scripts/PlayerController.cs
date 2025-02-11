using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent( typeof(CharacterController) )]
public class PlayerController : MonoBehaviour
{
    // Variables
    private PlayerControls playerControls;
    private Vector3 moveDirection;
    public float speed = 5.0f;              // Movement speed
    public float rotationSpeed = 2.0f;      // Rotation speed
    public float gravity = -9.81f;          // Gravity acceleration
    public float jumpHeight = 2.0f;         // How high the character can jump
    private Vector3 velocity;               // To track movement velocity
    private bool isGrounded;                // To check if the player is on the ground
    private CharacterController controller; // A reference for the CharacterController component
    public GameObject playerBody;
    public InputAction move;
    public InputAction jump;

    void Awake()
    {
        playerControls = new PlayerControls();
        controller = GetComponent<CharacterController>();
        playerBody = GameObject.Find("Player/PlayerBody");
        move = InputSystem.actions.FindAction("Move");
        jump = InputSystem.actions.FindAction("Jump");
    }

    void OnEnable() {
        playerControls.Enable();
    }

    void OnDisable() {
        playerControls.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = playerControls.Gameplay.Move.ReadValue<Vector3>();
        //Debug.Log("Move");

        // Normalize vector to ensure consistent speed in all directions
        if (moveDirection.magnitude > 1)
        {
            moveDirection.Normalize();
        }

        // Apply movement
        controller.Move(moveDirection * speed * Time.deltaTime);

        // Ground check - make sure the character is on the ground
        isGrounded = controller.isGrounded;

        // Gravity handling
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -3.0f;   // Reset Y velocity when on the ground
        }

        //playerControls.Gameplay.Jump.ReadValue<float>();
        //if (playerControls.Gameplay.Jump.triggered)
        if (playerControls.Gameplay.Jump.ReadValue<float>() == 1 && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);  // Jump calculation
            //Debug.Log("Jump");
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
