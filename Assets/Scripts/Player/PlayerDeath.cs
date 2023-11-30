using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private ParticleSystem deathParticles;
    [SerializeField] private KeyCode suicideKey = KeyCode.R;

    private bool suicideActive = false;

    public static event Action OnPlayerDeath;

    private void Start()
    {
        WallDetector.OnWallDetected += TriggerDeath;
        FallDetector.OnFallDetected += TriggerDeath;
        GameManager.OnGameStarted += ActivateSuicide;
        FinishLineDetector.OnFinishLinePassed += DeactivateSuicide;
    }

    private void Update()
    {
        if (!suicideActive) return;

        if (Input.GetKeyDown(suicideKey))
        {
            TriggerDeath();
        }
    }
    private void TriggerDeath()
    {
        deathParticles.Play();
        OnPlayerDeath?.Invoke();
        DeactivateSuicide();
    }

    private void ActivateSuicide()
    {
        suicideActive = true;
    }

    private void DeactivateSuicide()
    {
        suicideActive = false;
    }

    private void OnDestroy()
    {
        WallDetector.OnWallDetected -= TriggerDeath;
        FallDetector.OnFallDetected -= TriggerDeath;
        GameManager.OnGameStarted -= ActivateSuicide;
        FinishLineDetector.OnFinishLinePassed -= DeactivateSuicide;
    }


}
