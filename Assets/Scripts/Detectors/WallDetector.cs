using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDetector : MonoBehaviour
{

    public static event Action OnWallDetected;

    private void OnTriggerEnter(Collider other)
    {
        OnWallDetected?.Invoke();
    }
}
