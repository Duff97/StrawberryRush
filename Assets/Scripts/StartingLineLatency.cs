using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingLineLatency : MonoBehaviour
{
    private float velocity;
    private Vector3 initialPosition;

    private void Start()
    {
        velocity = FindAnyObjectByType<PlayerMovement>().GetVelocity();
        initialPosition = transform.position;
        GameManager.OnGameStarted += HandleGameStart;
    }

    private void HandleGameStart()
    {
        transform.position = initialPosition;
        float latency = Configuration.Instance.latency;
        float distance = (latency / 1000) * velocity;
        transform.Translate(new Vector3(-distance, 0));
    }

    private void OnDestroy()
    {
        GameManager.OnGameStarted -= HandleGameStart;
    }


}
