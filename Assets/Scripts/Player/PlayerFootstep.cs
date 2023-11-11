using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootstep : MonoBehaviour
{
    [SerializeField] private ParticleSystem footstepParticle;

    public static event Action OnFootstep;

    public void TriggerFootstep()
    {
        OnFootstep?.Invoke();
        footstepParticle.Play();
    }
} 
