using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpawner : MonoBehaviour
{
    [Header("Path Prefab to Spawn")]
    public GameObject pathPrefab;
    public float spawnPoint = 118f;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object has the Player tag
        if (other.CompareTag("Player"))
        {
            // Set spawn position with fixed y and z coordinates (0)
            Vector3 spawnPosition = new Vector3(-spawnPoint, 0f, 0f);

            // Spawn the path at the specified position with the prefab's original rotation
            GameObject spawnedPath = Instantiate(pathPrefab, spawnPosition, pathPrefab.transform.rotation);
        }
    }
}