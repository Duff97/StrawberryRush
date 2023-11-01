using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    private enum NoteValues { A4, A5, Ab4, Ab5, B4, B5, Bb4, Bb5, C4, C5, C6, D5, Eb4, Eb5, F5, G4, G5, Gb4, Gb5 };
    [SerializeField] private NoteValues noteValue;
    [SerializeField] private KeyCode collectKey = KeyCode.E;

    public static event Action<string> OnNoteCollected;

    private bool isCollectable = false;
    private NoteEffect effect;

    private void Start()
    {
        GameManager.OnGameStarted += HandleGameStart;
        effect = GetComponent<NoteEffect>();
    }

    private void Update()
    {
        if (!isCollectable || !Input.GetKeyDown(collectKey)) return;

        Collect();
    }

    private void OnTriggerEnter(Collider other)
    {        
        isCollectable = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isCollectable = false;
    }

    private void Collect()
    {
        OnNoteCollected?.Invoke(noteValue.ToString());
        gameObject.SetActive(false);

        isCollectable = false;

        if (effect != null)
        {
            effect.Activate();
        }
    }

    private void HandleGameStart()
    {
        gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        GameManager.OnGameStarted -= HandleGameStart;
    }
}
