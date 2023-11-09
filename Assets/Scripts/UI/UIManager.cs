using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject gamePanel;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.OnGameStarted += HandleGameStart;
        GameManager.OnGameFinished += HandleGameEnd;
    }

    private void HandleGameStart()
    {
        menuPanel.SetActive(false);
        gamePanel.SetActive(true);
    }

    private void HandleGameEnd()
    {
        menuPanel.SetActive(true);
        gamePanel.SetActive(false);
    }

    private void OnDestroy()
    {
        GameManager.OnGameStarted -= HandleGameStart;
        GameManager.OnGameFinished -= HandleGameEnd;
    }
}
