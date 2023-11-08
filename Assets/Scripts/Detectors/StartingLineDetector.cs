using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingLineDetector : MonoBehaviour
{
    public static event Action OnStartLinePassed;

    private void OnTriggerEnter(Collider other)
    {
        OnStartLinePassed?.Invoke();
    }
}
