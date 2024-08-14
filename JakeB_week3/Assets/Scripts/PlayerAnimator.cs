using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private const string IS_WALKING = "IsWalking";
    private const string DIE_TRIGGER = "IsDieing";

    private bool hasDied = false;

    private PlayerMovement playerMovement;
    private Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }


    void Update()
    {
        if (playerMovement.IsDieing() && !hasDied) {
            // Trigger the die animation only once
            animator.SetTrigger(DIE_TRIGGER);
            hasDied = true;
        } else {
            animator.SetBool(IS_WALKING, playerMovement.IsWalking());
        }
    }
}