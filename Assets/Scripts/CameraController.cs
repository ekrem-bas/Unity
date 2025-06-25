using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // the target object that the camera will follow
    public Vector3 offset = new Vector3(0, 3, -6); // distance between camera and target
    public float sensitivity = 3.0f; // mouse sensitivity
    // This prevents the camera from flipping over or looking too far
    public float minY = -30f; // minimum vertical angle
    public float maxY = 60f; // maximum vertical angle

    private float currentYaw = 0f; // current horizontal angle
    private float currentPitch = 10f; // current vertical angle

    // LateUpdate is called after all Update methods have been called
    void LateUpdate()
    {
        if (target == null) return;

        // Get mouse movement
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // Update the current yaw and pitch based on mouse movement
        currentYaw += mouseX; // Update horizontal rotation
        currentPitch -= mouseY; // Update vertical rotation
        // Clamp the pitch to prevent flipping
        currentPitch = Mathf.Clamp(currentPitch, minY, maxY);

        // Calculate the camera's rotation
        Quaternion rotation = Quaternion.Euler(currentPitch, currentYaw, 0);
        // Calculate the desired position of the camera
        Vector3 desiredPosition = target.position + rotation * offset;
        // Set the camera's position and rotation
        transform.position = desiredPosition;
        transform.LookAt(target.position);
    }
}
