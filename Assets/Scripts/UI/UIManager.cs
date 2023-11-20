using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject endGamePanel;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.OnGameStarted += HandleGameStart;
        GameManager.OnGameFinished += HandleGameEnd;
        FinishLineDetector.OnFinishLinePassed += HandlePreGameEnd;
        PlayerDeath.OnPlayerDeath += HandlePreGameEnd;
    }

    private void HandleGameStart()
    {
        menuPanel.SetActive(false);
        gamePanel.SetActive(true);
        endGamePanel.SetActive(false);
    }

    private void HandleGameEnd()
    {
        menuPanel.SetActive(true);
        gamePanel.SetActive(false);
        endGamePanel.SetActive(false);
    }

    private void HandlePreGameEnd()
    {
        endGamePanel.SetActive(true);
    }

    private void OnDestroy()
    {
        GameManager.OnGameStarted -= HandleGameStart;
        GameManager.OnGameFinished -= HandleGameEnd;
        FinishLineDetector.OnFinishLinePassed -= HandlePreGameEnd;
        PlayerDeath.OnPlayerDeath -= HandlePreGameEnd;
    }
}
