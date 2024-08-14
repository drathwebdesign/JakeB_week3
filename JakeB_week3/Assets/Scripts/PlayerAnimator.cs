using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private const string IS_WALKING = "IsWalking";

    private PlayerMovementTest playerMovementTest;
    private Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
        playerMovementTest = GetComponent<PlayerMovementTest>();
    }


    void Update()
    {
        animator.SetBool(IS_WALKING, playerMovementTest.IsWalking());
    }
}