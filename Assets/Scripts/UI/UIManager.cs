using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject winPanel;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.OnGameStarted += HandleGameStart;
        GameManager.OnGameFinished += HandleGameEnd;
        FinishLineDetector.OnFinishLinePassed += HandleFinishLinePassed;
    }

    private void HandleGameStart()
    {
        menuPanel.SetActive(false);
        gamePanel.SetActive(true);
        winPanel.SetActive(false);
    }

    private void HandleGameEnd()
    {
        menuPanel.SetActive(true);
        gamePanel.SetActive(false);
        winPanel.SetActive(false);
    }

    private void HandleFinishLinePassed()
    {
        winPanel.SetActive(true);
    }

    private void OnDestroy()
    {
        GameManager.OnGameStarted -= HandleGameStart;
        GameManager.OnGameFinished -= HandleGameEnd;
        FinishLineDetector.OnFinishLinePassed -= HandleFinishLinePassed;
    }
}
