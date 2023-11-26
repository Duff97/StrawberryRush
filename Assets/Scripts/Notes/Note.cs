using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Note : MonoBehaviour
{
    private enum NoteValues { A4, A5, Ab4, Ab5, B4, B5, Bb4, Bb5, C4, C5, C6, D5, Eb4, Eb5, F5, G4, G5, Gb4, Gb5 };
    private enum KeyValues { Z, X, C, AUTO }

    [SerializeField] private NoteValues noteValue;
    [SerializeField] private KeyValues keyValue;
    [SerializeField] private float AutoCollectHitBoxOffset;
    [SerializeField] private bool optional;

    [Header("Easy mode")]
    [SerializeField] private bool overrideForEasyMode;
    [SerializeField] private KeyValues easyKeyValue;

    [Header("References")]
    [SerializeField] private Material[] materials;
    [SerializeField] private Renderer noteRenderer;
    [SerializeField] private TMP_Text textField;
    [SerializeField] private BoxCollider hitbox;

    private KeyCode collectKey;

    public static event Action<string> OnNoteCollected;
    public static event Action OnNoteMissed;
    public static event Action OnOptionalNoteMissed;

    private bool isCollectable = false;
    private NoteEffect effect;

    private void Start()
    {
        GameManager.OnGameStarted += HandleGameStart;
        effect = GetComponent<NoteEffect>();
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
        if (collectKey == KeyCode.None)
            Collect();
        else
            isCollectable = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isCollectable = false;

        if (optional)
            OnOptionalNoteMissed?.Invoke();
        else
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
        collectKey = KeyToKeyCode(GetKeyValue().ToString());
        hitbox.center = new Vector3(GetKeyValue() == KeyValues.AUTO ? AutoCollectHitBoxOffset : 0, 0);

        SetNoteMaterial();
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
        noteRenderer.material = materials[(int)GetKeyValue()];
        textField.text = GetKeyValue().ToString() == "AUTO" ? "" : GetKeyValue().ToString();
    }

    private KeyValues GetKeyValue()
    {
        return (GameDifficulty.Instance.easyModeActivated && overrideForEasyMode) ? easyKeyValue : keyValue;
    }

    private void OnDestroy()
    {
        GameManager.OnGameStarted -= HandleGameStart;
    }
}
