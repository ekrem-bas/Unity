using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Player : MonoBehaviour
{
    // This script is attached to the player character and handles player movement using NavMeshAgent.
    // It allows the player to move around the scene by clicking on the ground.
    [SerializeField] private NavMeshAgent _agent = null;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Check for mouse input to set the destination for the NavMeshAgent
        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
            // Cast a ray from the camera to the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // Check if the ray hits a collider in the scene
            // If it does, set the destination of the NavMeshAgent to the hit point
            // This allows the player to click on the ground and move to that position
            RaycastHit hit;
            // Define a layer mask for the ground layer to filter raycast hits
            int groundLayerMask = LayerMask.GetMask("Ground");
            // If the ray hits something, set the agent's destination to the hit point
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayerMask))
            {
                // Set the destination of the NavMeshAgent to the point where the ray hit
                _agent.SetDestination(hit.point);
            }
        }
    }
}
