using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreCounter;

    private float _timeCounter;

    private void Awake()
    {
        _scoreCounter.text = "0";
    }

    public void SetScore(int newScore)
    {
        _scoreCounter.text = newScore.ToString();
    }
}
