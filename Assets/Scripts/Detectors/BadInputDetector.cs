using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadInputDetector : MonoBehaviour
{

    [SerializeField] private Collider collectZone;

    public static event Action OnBadInputDetected;

    private int overlappingColliders = 0;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (!Input.anyKeyDown) return;

        if (overlappingColliders == 0)
            OnBadInputDetected?.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        overlappingColliders++;
    }

    private void OnTriggerExit(Collider other)
    {
        if (overlappingColliders == 0) return;

        overlappingColliders--;
    }
}
