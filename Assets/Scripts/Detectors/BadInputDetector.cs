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
    }

    private void Update()
    {
        if (!Input.anyKeyDown || noteDetected) return;

        Debug.Log("RESET");
        OnBadInputDetected?.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trig enter");
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
}
