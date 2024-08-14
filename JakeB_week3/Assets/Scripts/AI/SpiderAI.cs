using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpiderAI : MonoBehaviour {

    private Transform playerTransform;
    public SpiderStats spiderStats;
    private PlayerMovement playerMovement;
    private ScoreManager scoreManager;

    private int currentHealth;

    //animations
    private bool isWalking;
    private bool isDieing;
    private bool isAttacking;

    void Start() {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform;
        playerMovement = player.GetComponent<PlayerMovement>();
        scoreManager = FindObjectOfType<ScoreManager>();
        currentHealth = spiderStats.maxHealth;
    }

    void Update() {
        //return stops all ai if its dieing
        if (isDieing) return;

        findPlayer();
    }

    void findPlayer() {
        // Make the animal face the player
        transform.LookAt(new Vector3(playerTransform.position.x, transform.position.y, playerTransform.position.z));

        //change moveSpeed to spiderStats.moveSpeed since we are referenceing another script
        transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, spiderStats.moveSpeed * Time.deltaTime);
        isWalking = true;
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.transform.tag == "Player") {
            isAttacking = true;
            if (playerMovement != null) {
                playerMovement.TakeDamage(1); // Deal 1 damage (adjust as necessary)
            }
            Destroy(gameObject, 1f); // Destroy this object
            Debug.Log("Hit Player");
        }
    }

    // Method to take damage
    public void TakeDamage(int damage) {
        if (isDieing) return; // Do nothing if the spider is already dying

        currentHealth -= damage;

        if (currentHealth <= 0) {
            Die();
        }
    }

    public void Die() {
        if (isDieing) return; // Stop Die from being called multiple times

        isDieing = true;
        // Stop the spider's movement immediately
        isWalking = false;
        isAttacking = false;
        
        scoreManager.AddScore(spiderStats.scoreValue); // Add the score value defined in SpiderStats
        
        Destroy(gameObject, 1f);
    }

        //animation fields
        public bool IsWalking() {
        return isWalking;
    }
    public bool IsDieing() {
        return isDieing;
    }
    public bool IsAttacking() {
        return isAttacking;
    }
}