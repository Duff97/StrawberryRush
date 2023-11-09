using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Note : MonoBehaviour
{
    private enum NoteValues { A4, A5, Ab4, Ab5, B4, B5, Bb4, Bb5, C4, C5, C6, D5, Eb4, Eb5, F5, G4, G5, Gb4, Gb5 };
    private enum KeyValues { Z, X, C }

    [SerializeField] private NoteValues noteValue;
    [SerializeField] private KeyValues keyValue;
    [SerializeField] private Material[] materials;
    [SerializeField] private Renderer noteRenderer;
    [SerializeField] private TMP_Text textField;

    private KeyCode collectKey;

    public static event Action<string> OnNoteCollected;
    public static event Action OnNoteMissed;

    private bool isCollectable = false;
    private NoteEffect effect;

    private void Start()
    {
        GameManager.OnGameStarted += HandleGameStart;
        effect = GetComponent<NoteEffect>();
        collectKey = KeyToKeyCode(keyValue.ToString());
        SetNoteMaterial();
    }

    private void Update()
    {
        if (!isCollectable) return;

        if (Input.GetKeyDown(collectKey))
            Collect();
        else if (Input.anyKeyDown)
            OnNoteMissed?.Invoke();

    }

    private void OnTriggerEnter(Collider other)
    {        
        isCollectable = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isCollectable = false;
        OnNoteMissed?.Invoke();
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

    private KeyCode KeyToKeyCode(string key)
    {
        switch (key)
        {
            case "Z": return KeyCode.Z;
            case "X": return KeyCode.X;
            case "C": return KeyCode.C;
            default: return KeyCode.None;
        }
    }

    private void SetNoteMaterial()
    {
        noteRenderer.material = materials[(int)keyValue];
        textField.text = keyValue.ToString();
    }

    private void OnDestroy()
    {
        GameManager.OnGameStarted -= HandleGameStart;
    }
}
