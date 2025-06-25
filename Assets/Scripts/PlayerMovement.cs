using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // public because we want to see it inside our inspector
    public float speed = 5.0f; // our player speed
    private float horizontalInput; // left-right movement
    private float forwardInput; // forward-back movement

    // Start is called before the first frame update
    void Start()
    {

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
    }
}
