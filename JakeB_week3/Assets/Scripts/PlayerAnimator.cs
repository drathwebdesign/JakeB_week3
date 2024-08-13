using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private const string IS_WALKING = "IsWalking";
    private const string IS_THROWING = "IsThrowing";

    private PlayerMovement playerMovement;
    private Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }


    void Update()
    {
        animator.SetBool(IS_WALKING, playerMovement.IsWalking());
        animator.SetBool(IS_THROWING, playerMovement.IsThrowing());
    }
}