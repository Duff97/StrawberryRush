using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{

    [SerializeField] private int noteNumber;

    public static event Action<int> OnNoteCollected;

    private void Start()
    {
        GameManager.OnGameStarted += HandleGameStart;
    }

    private void OnTriggerEnter(Collider other)
    {        
        OnNoteCollected?.Invoke(noteNumber);
        gameObject.SetActive(false);
    }

    private void HandleGameStart()
    {
        gameObject.SetActive(true);
    }
}
