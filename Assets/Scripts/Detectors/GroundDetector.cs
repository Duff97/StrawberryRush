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

    

    private void OnTriggerEnter(Collider other)
    {
        if (collidersDetectedAmount == 0)
        {
            OnGroundEntered?.Invoke();
            playerTransform.position = new Vector3(playerTransform.position.x, other.bounds.max.y - transform.localPosition.y);
        }

        collidersDetectedAmount++;

        
    }

    private void OnTriggerExit(Collider other)
    {
        collidersDetectedAmount--;

        if (collidersDetectedAmount == 0)
            OnGroundExited?.Invoke();
    }

    public bool IsGrounded()
    {
        return collidersDetectedAmount > 0;
    }
}
