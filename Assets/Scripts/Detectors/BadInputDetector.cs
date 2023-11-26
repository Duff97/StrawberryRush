using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadInputDetector : MonoBehaviour
{

    [SerializeField] private Collider collectZone;

    public static event Action OnBadInputDetected;

    private bool noteDetected;

    private void Start()
    {
        Note.OnNoteCollected += ResetNoteDetected;
        Note.OnNoteMissed += ResetNoteDetected;
        Note.OnOptionalNoteMissed += ResetNoteDetected;
    }

    private void Update()
    {
        if (!Input.anyKeyDown || noteDetected) return;

        OnBadInputDetected?.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        noteDetected = true;
    }

    private void ResetNoteDetected(string note)
    {
        noteDetected = false;
    }

    private void ResetNoteDetected()
    {
        noteDetected = false;
    }

    private void OnDestroy()
    {
        Note.OnNoteCollected -= ResetNoteDetected;
        Note.OnNoteMissed -= ResetNoteDetected;
        Note.OnOptionalNoteMissed -= ResetNoteDetected;
    }
}
