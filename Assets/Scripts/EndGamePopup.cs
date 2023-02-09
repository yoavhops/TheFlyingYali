using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndGamePopup : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _timerText;
    [SerializeField] private Timer _timer;

    public void ShowEndGame(int score)
    {
        gameObject.SetActive(true);
        _scoreText.text = score.ToString();
        _timerText.text = _timer.GetTimeText();
    }
}
