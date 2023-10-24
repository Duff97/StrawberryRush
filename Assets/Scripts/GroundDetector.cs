using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{

    public static event Action OnGroundEntered;
    public static event Action OnGroundExited;

    private void OnTriggerEnter(Collider other)
    {
        OnGroundEntered?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        OnGroundExited?.Invoke();
    }
}
