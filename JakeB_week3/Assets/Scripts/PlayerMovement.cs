using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float moveSpeed = 7f;
    float rotateSpeed = 10f;
    private PlayerControls playerControls;
    private Vector2 inputVector;

    //shooting
    public GameObject fish;
    public Transform firePoint;

    public float xRange;

    //animations
    private bool isWalking;
    private bool isThrowing;

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
        else if (transform.position.z > 18) {
            transform.position = new Vector3(transform.position.x, transform.position.y, 18);
        }
        if (transform.position.z < -4) {
            transform.position = new Vector3(transform.position.x, transform.position.y, -4);
        }
    }

    //change transform.position to firePoint
    void shoot() {
        if (Input.GetKey(KeyCode.F)) {
            Destroy(Instantiate(fish, firePoint.position, firePoint.rotation), 4);
            isThrowing = true;
        }
    }

    //animation fields
    public bool IsWalking() {
        return isWalking;
    }
    public bool IsThrowing() {
        return isThrowing;
    }
}