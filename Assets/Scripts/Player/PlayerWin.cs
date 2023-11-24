using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWin : MonoBehaviour
{
    [SerializeField] private GameObject textObj;

    private void Start()
    {
        GameManager.OnGameStarted += HideText;
        FinishLineDetector.OnFinishLinePassed += ShowText;
    }

    private void ShowText()
    {
        textObj.SetActive(true);
    }

    private void HideText()
    {
        textObj.SetActive(false);
    }

    private void OnDestroy()
    {
        GameManager.OnGameStarted -= HideText;
        FinishLineDetector.OnFinishLinePassed -= ShowText;
    }
}
