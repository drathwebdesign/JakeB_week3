using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMovement : MonoBehaviour {
    public float moveSpeed = 5f;
    private Transform playerTransform;

    void Start() {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null) {
            playerTransform = player.transform;
        }
    }


    void Update() {
        findPlayer();
    }

    void findPlayer() {
        // Make the animal face the player
        transform.LookAt(new Vector3(playerTransform.position.x, transform.position.y, playerTransform.position.z));

        transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, moveSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.transform.tag == "Player") {
            Destroy(gameObject); // Destroy this object
            Debug.Log("Hit Player");
        }
    }
}