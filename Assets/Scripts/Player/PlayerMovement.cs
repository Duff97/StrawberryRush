using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float velocity;
    [SerializeField] private ConstantForce gravity;
    
    private Rigidbody rb;
    private bool isInGame = false;
    private Vector3 startPosition;
    private bool adjustVelocity = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
        GameManager.OnGameStarted += HandleGameStarted;
        FinishLineDetector.OnFinishLinePassed += HandleGameFinished;
        PlayerDeath.OnPlayerDeath += HandleGameFinished;
        GroundDetector.OnGroundEntered += HandleGroundEntered;
        GroundDetector.OnGroundExited += HandleGroundExited;
        FlyEffect.OnActivated += HandleFlightStarted;
        FlyEffect.OnDeactivated += HandleFlightExited;
    }

    private void FixedUpdate()
    {

        if (!isInGame) return;

        if (adjustVelocity && !gravity.enabled && rb.velocity.y != 0)
        {
            rb.velocity = new Vector3(velocity, 0);
        }
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

    private void HandleGroundEntered()
    {
        rb.velocity = new Vector3(velocity, 0);
        gravity.enabled = false;
    }

    private void HandleGroundExited()
    {
        gravity.enabled = true;
    }

    private void HandleFlightStarted()
    {
        gravity.enabled = false;
        adjustVelocity = false;
    }

    private void HandleFlightExited()
    {
        adjustVelocity = true;
    }

    private void OnDestroy()
    {
        GameManager.OnGameStarted -= HandleGameStarted;
        FinishLineDetector.OnFinishLinePassed -= HandleGameFinished;
        PlayerDeath.OnPlayerDeath -= HandleGameFinished;
        GroundDetector.OnGroundEntered -= HandleGroundEntered;
        GroundDetector.OnGroundExited -= HandleGroundExited;
        FlyEffect.OnActivated -= HandleFlightStarted;
        FlyEffect.OnDeactivated -= HandleFlightExited;
    }
}
