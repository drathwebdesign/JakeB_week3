using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float moveSpeed = 7f;
    float rotateSpeed = 10f;
    private PlayerControls playerControls;
    private Vector2 inputVector;

    //animations
    private bool isWalking;

    void Awake() {
        playerControls = new PlayerControls();
        playerControls.Player.Enable();
    }

    void Update() {
        HandleMovement();
    }

    private void HandleMovement() {
        inputVector = playerControls.Player.Move.ReadValue<Vector2>();

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        transform.position += moveDir * moveSpeed * Time.deltaTime;

        //is walking for animations
        isWalking = moveDir != Vector3.zero;

        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
    }

    //animation fields
    public bool IsWalking() {
        return isWalking;
    }
}