using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float detectionDistance;

    private bool groundDetected = false;

    public static event Action OnGroundEntered;
    public static event Action OnGroundExited;


    private void Update()
    {
        bool wasGrounded = groundDetected;
        groundDetected = Physics.Raycast(transform.position, Vector3.down, detectionDistance, groundLayer);

        if (wasGrounded == groundDetected) return;

        if (groundDetected)
            OnGroundEntered?.Invoke();
        else
            OnGroundExited?.Invoke();
    }

    public bool IsGrounded()
    {
        return groundDetected;
    }
}
