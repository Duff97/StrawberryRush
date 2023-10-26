using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;

    public static event Action OnGameStarted;
    public static event Action OnGameFinished;

    public void StartGame()
    {
        menuPanel.SetActive(false);
        OnGameStarted?.Invoke();
    }

    public void EndGame()
    {
        menuPanel.SetActive(true);
        OnGameFinished?.Invoke();
    }
}
