using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float detectionDistance;

    private bool groundDetected = false;

    private void FixedUpdate()
    {
        groundDetected = Physics.Raycast(transform.position, Vector3.down, detectionDistance);
    }

    public bool isGrounded()
    {
        return groundDetected;
    }
}
