using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text timeText;
    private float timeLeft;

    private const int GAME_TIME = 20;

    // Start is called before the first frame update
    void Start()
    {
        StartingLineDetector.OnStartLinePassed += HandleStartLinePassed;
        GameManager.OnGameStarted += HandleGameStarted;
        GameManager.OnGameFinished += HandleGameFinished;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft == 0) return;

        timeLeft -= Time.deltaTime;
        if (timeLeft < 0) timeLeft = 0;

        timeText.text = timeLeft.ToString("##.##");

    }

    private void HandleStartLinePassed()
    {
        timeLeft = GAME_TIME;
    }

    private void HandleGameFinished()
    {
        timeLeft = 0;
    }

    private void HandleGameStarted()
    {
        timeText.text = $"{GAME_TIME}:00";
    }

    private void OnDestroy()
    {
        StartingLineDetector.OnStartLinePassed -= HandleStartLinePassed;
        GameManager.OnGameStarted -= HandleGameStarted;
        GameManager.OnGameFinished -= HandleGameFinished;
    }
}
