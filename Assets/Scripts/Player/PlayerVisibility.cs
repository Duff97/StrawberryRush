using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisibility : MonoBehaviour
{

    [SerializeField] private Renderer playerRenderer;
    [SerializeField] private Renderer collectZoneRenderer;
    [SerializeField] private TrailRenderer trail;

    void Start()
    {
        GameManager.OnGameStarted += Show;
        PlayerDeath.OnPlayerDeath += Hide;
    }

    private void Hide()
    {
        playerRenderer.enabled = false;
        collectZoneRenderer.enabled = false;
        trail.Clear();
    }

    private void Show()
    {
        playerRenderer.enabled = true;
        collectZoneRenderer.enabled = true;
    }

    private void OnDestroy()
    {
        GameManager.OnGameStarted -= Show;
        PlayerDeath.OnPlayerDeath -= Hide;
    }
}
