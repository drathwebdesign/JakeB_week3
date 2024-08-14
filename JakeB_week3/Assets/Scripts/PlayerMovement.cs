using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    //animations
    private bool isWalking;

    void Awake() {
        playerControls = new PlayerControls();
        playerControls.Player.Enable();
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

    //animation fields
    public bool IsWalking() {
        return isWalking;
    }
}