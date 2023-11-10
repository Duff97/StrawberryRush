using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDifficulty : MonoBehaviour
{
    public bool easyModeActivated {  get; private set; }

    public static GameDifficulty Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void SetEasyMode(bool active)
    {
        easyModeActivated = active;
    }
}
