using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    public GameObject[] prefabsToSpawn; // Array to hold multiple prefabs
    public float spawnInterval = 2f; // Time interval between spawns

    void Start()
    {
        // Start spawning prefabs at regular intervals
        InvokeRepeating("SpawnPrefab", 0f, spawnInterval);
    }

    void SpawnPrefab()
    {
        if (prefabsToSpawn.Length > 0)
        {
            // Randomly select a prefab from the array
            int randomIndex = Random.Range(0, prefabsToSpawn.Length);
            GameObject selectedPrefab = prefabsToSpawn[randomIndex];

            // Get the original position of the prefab
            Vector3 originalPosition = selectedPrefab.transform.position;

            // Set the spawn position with x = 100 and y, z from the prefab's original position
            Vector3 spawnPosition = new Vector3(-80f, originalPosition.y, originalPosition.z);

            // Instantiate the prefab at the specified spawn position
            Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("No prefabs assigned to spawn!");
        }
    }
}