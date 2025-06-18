using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : MonoBehaviour
{
    [Header("Movement Speed")]
    public float moveSpeed = 10f;
    public float destroyDestance = 70;

    private void Update()
    {
        // Move the path to the right (along the +X axis)
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;

        // Check if the path's x position has reached or exceeded 70
        if (transform.position.x >= destroyDestance)
        {
            Destroy(gameObject);
        }
    }
}
