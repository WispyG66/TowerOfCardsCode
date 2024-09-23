using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Reference to the player object
    public Transform player;

    // Offset position from the player
    private Vector3 offset;

    // Fixed rotation for the camera
    private Vector3 fixedRotation = new Vector3(30f, 0f, 0f); // Change these values as needed

    // Smoothing speed
    private float smoothingSpeed = 0.01f;

    void Start()
    {
        // Calculate and store the offset value by getting the distance between the player's position and camera's position
        offset = transform.position - player.position;

        // Set the camera's rotation to the fixed rotation
        transform.eulerAngles = fixedRotation;
    }

    void LateUpdate()
    {
        // Calculate the target position based on the player's position and the offset
        Vector3 targetPosition = player.position + offset;

        // Smoothly interpolate between the current position and the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothingSpeed);

        // Ensure the camera's rotation remains fixed
        transform.eulerAngles = fixedRotation;
    }
}
