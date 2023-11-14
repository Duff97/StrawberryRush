using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GroundDetector groundDetector;

    // Start is called before the first frame update
    void Start()
    {
        JumpEffect.OnActivated += HandlePlayerJump;
        FlyEffect.OnActivated += HandleFlightStart;
        FlyEffect.OnDeactivated += HandleFlightEnd;
        FinishLineDetector.OnFinishLinePassed += HandleFinishLinePassed;
        GameManager.OnGameStarted += HandleGameStart;
    }

    private void FixedUpdate()
    {
        animator.SetBool("IsOnGround", groundDetector.IsGrounded());
    }

    private void HandlePlayerJump()
    {
        animator.SetTrigger("Jump");
    }

    private void HandleFlightStart()
    {
        animator.SetBool("IsFlying", true);
        animator.SetTrigger("Fly");
    }

    private void HandleFlightEnd()
    {
        animator.SetBool("IsFlying", false);
    }

    private void HandleFinishLinePassed()
    {
        animator.SetBool("IsIdle", true);
        animator.SetTrigger("Celebrate");
    }

    private void HandleGameStart()
    {
        animator.SetBool("IsIdle", false);
    }

    private void OnDestroy()
    {
        JumpEffect.OnActivated -= HandlePlayerJump;
        FlyEffect.OnActivated -= HandleFlightStart;
        FlyEffect.OnDeactivated -= HandleFlightEnd;
        FinishLineDetector.OnFinishLinePassed -= HandleFinishLinePassed;
    }

}
