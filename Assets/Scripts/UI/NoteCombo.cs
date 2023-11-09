using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NoteCombo : MonoBehaviour
{
    [SerializeField] private TMP_Text comboText;
    private int currentCombo;

    // Start is called before the first frame update
    void Start()
    {
        Note.OnNoteCollected += Increment;
        Note.OnNoteMissed += ResetCount;
        GameManager.OnGameStarted += ResetCount;
    }

    private void ResetCount()
    {
        currentCombo = 0;
        RefreshComboText();
    }

    private void Increment(string note)
    {
        currentCombo++;
        RefreshComboText();
    }

    private void RefreshComboText()
    {
        comboText.text = $"Combo: {currentCombo}";
    }

    private void OnDestroy()
    {
        Note.OnNoteCollected -= Increment;
        Note.OnNoteMissed -= ResetCount;
    }
}
