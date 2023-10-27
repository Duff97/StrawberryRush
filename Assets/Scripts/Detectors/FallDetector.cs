using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDetector : MonoBehaviour
{
    public static event Action OnFallDetected;

    private void OnTriggerEnter(Collider other)
    {
        OnFallDetected?.Invoke();
    }
}
