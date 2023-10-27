using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineDetector : MonoBehaviour
{
    public static event Action OnFinishLinePassed;

    private void OnTriggerEnter(Collider other)
    {
        OnFinishLinePassed?.Invoke();
    }
}
