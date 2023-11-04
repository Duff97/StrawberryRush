using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrail : MonoBehaviour
{
    [SerializeField] private TrailRenderer trail;

    private void Start()
    {
        GameManager.OnGameStarted += HandleGameStarted;
    }

    private void HandleGameStarted()
    {
        Invoke(nameof(ClearTrail), 0.01f);
    }

    private void ClearTrail()
    {
        trail.Clear();
    }


    private void OnDestroy()
    {
        GameManager.OnGameStarted -= HandleGameStarted;
    }
}
