using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    private enum NoteValues { A4, A5, Ab4, Ab5, B4, B5, Bb4, Bb5, C4, C5, C6, D5, Eb4, Eb5, F5, G4, G5, Gb4, Gb5 };
    [SerializeField] private NoteValues noteValue;

    public static event Action<string> OnNoteCollected;

    private void Start()
    {
        GameManager.OnGameStarted += HandleGameStart;
    }

    private void OnTriggerEnter(Collider other)
    {        
        OnNoteCollected?.Invoke(noteValue.ToString());
        gameObject.SetActive(false);
    }

    private void HandleGameStart()
    {
        gameObject.SetActive(true);
    }
}
