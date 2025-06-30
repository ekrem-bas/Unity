using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // The target to follow (player)
    public Transform target;
    // Camera position relative to the target (suitable offset for isometric view)
    public Vector3 offset = new Vector3(-7, 10, -7);
    // Camera follow speed
    public float followSpeed = 10f;

    // LateUpdate is called after all Update methods have been called.
    // This is useful for camera movement because it ensures that the camera follows the target after all
    void LateUpdate()
    {
        // Check if the target is assigned
        if (target != null)
        {
            // Calculate the desired position based on the target's position and the offset
            Vector3 desiredPosition = target.position + offset;
            // Smoothly move the camera towards the desired position
            // Using Lerp for smooth transition
            transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);
            // Set the camera rotation to an isometric angle
            transform.rotation = Quaternion.Euler(45, 45, 0);
        }
    }
}
