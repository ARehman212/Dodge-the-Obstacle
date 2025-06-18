using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;         // Speed at which the player moves
    public float maxZPosition = 10f;     // Maximum Z position limit
    public float minZPosition = -10f;    // Minimum Z position limit

    private float lastTouchPositionX;    // To store the last touch position on the X-axis

    void Update()
    {
        // Handle touch input
        if (Input.touchCount > 0)
        {
            HandleTouchInput();
        }
        else
        {
            HandleKeyboardInput();
        }
    }

    void HandleTouchInput()
    {
        Touch touch = Input.GetTouch(0); // Get the first touch

        if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Began)
        {
            float moveZ = (touch.position.x - lastTouchPositionX) * moveSpeed * Time.deltaTime;
            MovePlayer(moveZ);
        }

        lastTouchPositionX = touch.position.x;
    }

    void HandleKeyboardInput()
    {
        // Get horizontal input (-1 to 1 for A/D or Left/Right arrows)
        float input = Input.GetAxis("Horizontal");
        float moveZ = input * moveSpeed * Time.deltaTime;

        MovePlayer(moveZ);
    }

    void MovePlayer(float moveZ)
    {
        Vector3 movement = new Vector3(0, 0, moveZ);
        Vector3 newPosition = transform.position + movement;

        // Clamp the Z position
        newPosition.z = Mathf.Clamp(newPosition.z, minZPosition, maxZPosition);

        transform.position = newPosition;
    }
}