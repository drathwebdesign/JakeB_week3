using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSpawner : MonoBehaviour {
    public GameObject animalPrefab; // The animal to spawn
    public float spawnRate = 1f; // Time between spawns
    public float spawnRangeX = 20f; // The X-axis range for spawning
    public float spawnRangeZMin = -10f; // The minimum Z value for spawning
    public float spawnRangeZMax = 30f; // The maximum Z value for spawning
    public LayerMask groundLayer; // Layer mask for the ground

    private PlayerMovement player;

    void Start() {
        player = FindObjectOfType<PlayerMovement>(); // Find the player in the scene
        InvokeRepeating("SpawnAnimal", 2f, spawnRate); // Start spawning animals 2f= time until first spawn
    }

    void SpawnAnimal() {
        Vector3 spawnPosition;

        // Loop until a valid spawn position is found
        do {
            float spawnPosX = Random.Range(-spawnRangeX, spawnRangeX);
            float spawnPosZ = Random.Range(spawnRangeZMin, spawnRangeZMax);
            spawnPosition = new Vector3(spawnPosX, 0, spawnPosZ);
        } while (IsWithinPlayerBounds(spawnPosition) || !IsGround(spawnPosition));

        // Spawn the animal at the valid position
        Instantiate(animalPrefab, spawnPosition, Quaternion.identity);
    }

    bool IsWithinPlayerBounds(Vector3 position) {
        float xRange = player.xRange;
        float zMax = 18f; // Corresponds to your player's Z bounds
        float zMin = -4f;

        return position.x >= -xRange && position.x <= xRange && position.z >= zMin && position.z <= zMax;
    }

    bool IsGround(Vector3 position) {
        // Check if the position is on the ground using a raycast
        Ray ray = new Ray(position + Vector3.up * 10f, Vector3.down); // Cast a ray downward from above the position
        return Physics.Raycast(ray, 20f, groundLayer);
    }
}