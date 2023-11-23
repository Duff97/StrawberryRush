using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text timeText;
    private float timeLeft;
    private bool paused = true;
    private const int GAME_TIME = 20;
    

    // Start is called before the first frame update
    void Start()
    {
        StartingLineDetector.OnStartLinePassed += UnPause;
        GameManager.OnGameStarted += ResetTime;
        PlayerDeath.OnPlayerDeath += Pause;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft == 0 || paused) return;

        timeLeft -= Time.deltaTime;
        if (timeLeft < 0) timeLeft = 0;

        timeText.text = timeLeft.ToString("##.##");

    }

    private void ResetTime()
    {
        timeLeft = GAME_TIME;
        timeText.text = $"{GAME_TIME}:00";
        paused = true;
    }

    private void Pause()
    {
        paused = true;
    }

    private void UnPause()
    {
        paused = false;
    }

    private void OnDestroy()
    {
        StartingLineDetector.OnStartLinePassed -= UnPause;
        GameManager.OnGameStarted -= ResetTime;
        PlayerDeath.OnPlayerDeath -= Pause;
    }
}
