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
        PlayerMovement.OnPlayerJump += HandlePlayerJump;
    }

    private void FixedUpdate()
    {
        animator.SetBool("IsOnGround", groundDetector.IsGrounded());
    }

    private void HandlePlayerJump()
    {
        animator.SetTrigger("Jump");
    }

    private void OnDestroy()
    {
        PlayerMovement.OnPlayerJump -= HandlePlayerJump;
    }

}
