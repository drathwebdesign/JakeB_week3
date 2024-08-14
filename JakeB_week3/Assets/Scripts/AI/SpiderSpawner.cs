using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderSpawner : MonoBehaviour {
    public GameObject[] spiderPrefabs; // The spiders to spawn
    public float spawnRate = 1f; // Time between spawns
    public float spawnRangeX = 55f; // The X-axis range for spawning
    public float spawnRangeZ = 35f; // The Z- axis range for spawning
    public LayerMask groundLayer; // Layer mask for the ground

    private PlayerMovement player;

    void Start() {
        player = FindObjectOfType<PlayerMovement>(); // Find the player in the scene
        InvokeRepeating("SpawnSpider", 2f, spawnRate); // Start spawning spiders
    }

    void SpawnSpider() {
        Vector3 spawnPosition;

        // Loop until a valid spawn position is found
        do {
            float spawnPosX = Random.Range(-spawnRangeX, spawnRangeX);
            float spawnPosZ = Random.Range(-spawnRangeZ, spawnRangeZ);
            spawnPosition = new Vector3(spawnPosX, 0, spawnPosZ);
        } while (IsWithinPlayerBounds(spawnPosition) || !IsGround(spawnPosition));

        // Randomly select a spider prefab from the array
        int randomIndex = Random.Range(0, spiderPrefabs.Length);
        GameObject selectedSpiderPrefab = spiderPrefabs[randomIndex];

        // Spawn the spider at the valid position
        Instantiate(selectedSpiderPrefab, spawnPosition, Quaternion.identity);
    }

    bool IsWithinPlayerBounds(Vector3 position) {
        float xRange = player.xRange;
        float zRange = player.zRange;

        // Check if the position is within the player's X and Z bounds
        bool withinXBounds = position.x >= -xRange && position.x <= xRange;
        bool withinZBounds = position.z >= -zRange && position.z <= zRange;

        // Return true if the position is within both X and Z bounds
        return withinXBounds && withinZBounds;
    }

    bool IsGround(Vector3 position) {
        // Check if the position is on the ground using a raycast
        Ray ray = new Ray(position + Vector3.up * 10f, Vector3.down); // Cast a ray downward from above the position
        return Physics.Raycast(ray, 20f, groundLayer);
    }
}
