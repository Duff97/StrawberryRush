using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{

    public static event Action OnGameStarted;
    public static event Action OnGameFinished;

    private void Start()
    {
        FallDetector.OnFallDetected += EndGame;
        WallDetector.OnWallDetected += EndGame;
        FinishLineDetector.OnFinishLinePassed += EndGame;
    }

    public void StartGame()
    {
        OnGameStarted?.Invoke();
    }

    public void EndGame()
    {
        OnGameFinished?.Invoke();
    }
}
