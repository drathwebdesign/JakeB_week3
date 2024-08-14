using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAnimator : MonoBehaviour
{
    private const string IS_WALKING = "IsWalking";
    private const string DIE_TRIGGER = "IsDieing";
    private const string ATTACK_TRIGGER = "IsAttacking";

    private bool hasDied = false;

    private SpiderAI spiderAI;
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
        spiderAI = GetComponent<SpiderAI>();
    }

    void Update() {
        if (spiderAI.IsDieing() && !hasDied) {
            // Trigger the die animation only once
            animator.SetTrigger(DIE_TRIGGER);
            hasDied = true;
        } else if (spiderAI.IsAttacking()) {
            // Trigger the attack animation
            animator.SetTrigger(ATTACK_TRIGGER);
        } else {
            // Set walking animation
            animator.SetBool(IS_WALKING, spiderAI.IsWalking());
        }
    }
}