using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

    public float moveSpeed = 7f;
    float rotateSpeed = 10f;
    private PlayerControls playerControls;
    private Vector2 inputVector;

    //shooting
    public GameObject bullet;
    public Transform firePoint;

    public float xRange = 50f;
    public float zRange = 28f;

    //health & invulnerability
    public int maxHealth = 3; 
    private int currentHealth;
    private bool isInvulnerable = false;
    public float invulnerabilityDuration = 1f;

    //animations
    private bool isWalking;
    private bool isDieing;

    void Awake() {
        playerControls = new PlayerControls();
        playerControls.Player.Enable();

        currentHealth = maxHealth;
    }

    void Update() {
        HandleMovement();
        bounds();
        shoot();
    }

    private void HandleMovement() {
        inputVector = playerControls.Player.Move.ReadValue<Vector2>();

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        transform.position += moveDir * moveSpeed * Time.deltaTime;

        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
        //is walking for animations
        isWalking = moveDir != Vector3.zero;
    }

    void bounds() {
        if(transform.position.x >= xRange) {
            transform.position = new Vector3(xRange, 0, transform.position.z);
        }
        if (transform.position.x <= -xRange) {
            transform.position = new Vector3(-xRange, 0, transform.position.z);
        }
        else if (transform.position.z > zRange) {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }
        if (transform.position.z < -zRange) {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }
    }

    //change transform.position to firePoint
    void shoot() {
        if (Input.GetKey(KeyCode.Space)) {
            Destroy(Instantiate(bullet, firePoint.position, firePoint.rotation), 4);
        }
    }

    public void TakeDamage(int damage) {
        if (!isInvulnerable) {
            currentHealth -= damage;

            if (currentHealth <= 0) {
                Die();
            } else {
                StartCoroutine(InvulnerabilityCoroutine());
            }
        }
    }

    private void Die() {
        Debug.Log("Player has died!");
        if (isDieing) return; // Stop Die from being called multiple times

        isDieing = true;
        // Stop the spider's movement immediately
        isWalking = false;
        Destroy(gameObject, 3f);
    }

    private IEnumerator InvulnerabilityCoroutine() {
        isInvulnerable = true;
        yield return new WaitForSeconds(invulnerabilityDuration);
        isInvulnerable = false;
    }

    //animation fields
    public bool IsWalking() {
        return isWalking;
    }
    public bool IsDieing() {
        return isDieing;
    }
}