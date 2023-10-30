using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float velocity;
    [SerializeField] private float jumpVelocity;
    [SerializeField] private KeyCode jumpKey;
    [SerializeField] private ConstantForce gravity;

    private Rigidbody rb;
    private bool isInGame = false;
    private Vector3 startPosition;
    private bool jumpActive = false;

    public static event Action OnPlayerJump;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
        GameManager.OnGameStarted += HandleGameStarted;
        GameManager.OnGameFinished += HandleGameFinished;
        GroundDetector.OnGroundEntered += HandleGroundDetected;
        GroundDetector.OnGroundExited += HandleGroundExited;
    }

    private void FixedUpdate()
    {

        if (!isInGame) return;

        if (jumpActive && rb.velocity.y != 0)
        {
            rb.velocity = new Vector3(velocity, 0);
        }

        if (jumpActive && Input.GetKey(jumpKey))
        {
            Jump();
        }
        
    }

    private void Jump()
    {    
        rb.velocity = new Vector3(velocity, jumpVelocity);
        jumpActive = false;
        OnPlayerJump?.Invoke();
    }

    private void HandleGameStarted()
    {
        gravity.enabled = true;
        transform.position = startPosition;
        isInGame = true;
        rb.velocity = new Vector3(velocity, 0);
    }

    private void HandleGameFinished()
    {
        gravity.enabled = false;
        rb.velocity = Vector3.zero;
        isInGame = false;
    }

    private void HandleGroundDetected()
    {
        gravity.enabled = false;
        jumpActive = true;
    }

    private void HandleGroundExited()
    {
        gravity.enabled = true;
        jumpActive = false;
    }

    private void OnDestroy()
    {
        GameManager.OnGameStarted -= HandleGameStarted;
        GameManager.OnGameStarted -= HandleGameFinished;
        GroundDetector.OnGroundEntered -= HandleGroundDetected;
        GroundDetector.OnGroundExited -= HandleGroundExited;
    }
}
