using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    private int collidersDetectedAmount = 0;

    public static event Action OnGroundEntered;
    public static event Action OnGroundExited;

    private bool isFlying = false;

    private void Start()
    {
        FlyEffect.OnActivated += HandleFlightStarted;
        FlyEffect.OnDeactivated += HandleFlightEnded;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (collidersDetectedAmount == 0 && !isFlying)
        {
            OnGroundEntered?.Invoke();
            playerTransform.position = new Vector3(playerTransform.position.x, other.bounds.max.y - transform.localPosition.y);
        }

        collidersDetectedAmount++;

        
    }

    private void OnTriggerExit(Collider other)
    {
        collidersDetectedAmount--;

        if (collidersDetectedAmount == 0 && !isFlying)
            OnGroundExited?.Invoke();
    }

    private void HandleFlightStarted()
    {
        isFlying = true;
    }

    private void HandleFlightEnded()
    {
        isFlying = false;

        if (collidersDetectedAmount == 0)
            OnGroundExited?.Invoke();
        else
            OnGroundEntered?.Invoke();
    }

    public bool IsGrounded()
    {
        return collidersDetectedAmount > 0;
    }

    private void OnDestroy()
    {
        FlyEffect.OnActivated -= HandleFlightStarted;
        FlyEffect.OnDeactivated -= HandleFlightEnded;
    }
}
