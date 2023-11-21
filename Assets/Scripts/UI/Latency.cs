using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Latency : MonoBehaviour
{
    [SerializeField] private Slider latencySlider;
    [SerializeField] private TMP_Text latencyText;
    private void Start()
    {
        latencySlider.value = Configuration.Instance.latency;
    }

    public void SetLatency(float latency)
    {
        Configuration.Instance.latency = latency;
        latencyText.text = $"Latency [{(float)Math.Round(latency, 2)} ms] :";
    }
}
