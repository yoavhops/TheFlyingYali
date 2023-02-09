using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text _timerText;

    private float _timeCounter;

    private void Awake()
    {
        _timeCounter = 0;
    }

    void Update()
    {
        _timeCounter += Time.deltaTime;
        TimeSpan timeSpan = TimeSpan.FromSeconds(_timeCounter);
        _timerText.text = timeSpan.ToString(@"mm\:ss");
    }

    public string GetTimeText()
    {
        return _timerText.text;
    }
}
