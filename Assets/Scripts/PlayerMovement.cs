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

    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody component attached to the player GameObject
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // get player input
        // horizontal and vertical already defined in Unity's Input Manager
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // Move the player forward
        // Vector3.forward is moving the player in the Z direction
        // Vector3.right is moving the player in the X direction
        // Time.deltaTime is used to make the movement frame rate independent
        // speed is multiplied by the input to control the speed of movement
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

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
