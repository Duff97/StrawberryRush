using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineDetector : MonoBehaviour
{
    [SerializeField] private GameObject finishText;

    public static event Action OnFinishLinePassed;

    private void Start()
    {
        GameManager.OnGameStarted += HandleGameStart;
    }

    private void OnTriggerEnter(Collider other)
    {
        finishText.SetActive(true);
        OnFinishLinePassed?.Invoke();
    }

    private void HandleGameStart()
    {
        finishText.SetActive(false);
    }

    private void OnDestroy()
    {
        GameManager.OnGameStarted -= HandleGameStart;
    }
}
