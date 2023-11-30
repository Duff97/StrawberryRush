using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerFootstep : MonoBehaviour
{
    [SerializeField] private ParticleSystem footstepParticle;

    public static event Action OnFootstep;

    private bool active = false;

    private void Start()
    {
        GameManager.OnGameStarted += Activate;
        PlayerDeath.OnPlayerDeath += Deactivate;
    }

    public void TriggerFootstep()
    {
        if (!active) return;

        OnFootstep?.Invoke();
        footstepParticle.Play();
    }

    private void Activate()
    {
        active = true;
    }

    private void Deactivate()
    {
        active = false;
    }

    private void OnDestroy()
    {
        GameManager.OnGameStarted -= Activate;
        PlayerDeath.OnPlayerDeath -= Deactivate;
    }
} 
