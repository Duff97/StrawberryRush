using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static event Action OnGameStarted;
    public static event Action OnGameFinished;

    public void StartGame()
    {
        OnGameStarted?.Invoke();
    }

    public void EndGame()
    {
        OnGameFinished?.Invoke();
    }
}
