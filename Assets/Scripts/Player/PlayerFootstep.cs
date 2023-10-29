using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootstep : MonoBehaviour
{
    public static event Action OnFootstep;

    public void TriggerFootstep()
    {
        OnFootstep?.Invoke();
    }
} 
