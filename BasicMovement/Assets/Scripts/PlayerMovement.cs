using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // public because we want to see it inside our inspector
    public float speed = 5.0f; // our player speed
    public float jumpForce = 5.0f; // force applied when jumping
    private float horizontalInput; // left-right movement
    private float forwardInput; // forward-back movement
    // Rigidbody is a component that allows us to apply physics to the player, like jumping
    // we will use it to apply forces like jumping
    public Rigidbody playerRb; // reference to the player's Rigidbody component
    private bool isOnGround = true; // to check if the player is on the ground
    public Transform cameraTransform; // reference to the camera's transform to calculate movement direction

    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody component attached to the player GameObject
        playerRb = GetComponent<Rigidbody>();
        cameraTransform = Camera.main.transform; // Get the main camera's transform
    }

    // Update is called once per frame
    void Update()
    {
        // get player input
        // horizontal and vertical already defined in Unity's Input Manager
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // calculate the movement direction based on camera orientation
        // we will use the camera's forward and right vectors to determine the movement direction
        // we will ignore the Y component to keep the movement on the horizontal plane
        Vector3 camForward = cameraTransform.forward; // Get the camera's forward direction
        Vector3 camRight = cameraTransform.right; // Get the camera's right direction
        camForward.y = 0f; // Reset the Y axis to keep movement on the horizontal plane
        camRight.y = 0f; // Reset the Y axis to keep movement on the horizontal plane
        // Normalize the vectors to ensure consistent movement speed
        camForward.Normalize();
        camRight.Normalize();
        // calculate the movement direction based on input and camera orientation
        Vector3 moveDir = camForward * forwardInput + camRight * horizontalInput;
        transform.Translate(moveDir * Time.deltaTime * speed, Space.World);

        // let the player jump
        // check if the player is pressing the jump button (spacebar by default)
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false; // set isOnGround to false when jumping
        }
    }

    // This method is called when the player collides with another collider
    // We use it to check if the player is on the ground
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            // if the player collides with the ground, set isOnGround to true
            isOnGround = true;
        }
    }
}
