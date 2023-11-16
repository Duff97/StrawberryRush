using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private ParticleSystem deathParticles;

    public static event Action OnPlayerDeath;

    private void Start()
    {
        WallDetector.OnWallDetected += TriggerDeath;
        FallDetector.OnFallDetected += TriggerDeath;
    }
    private void TriggerDeath()
    {
        deathParticles.Play();
        OnPlayerDeath?.Invoke();
    }


}
