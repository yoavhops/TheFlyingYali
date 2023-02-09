using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public int GameType;

    [SerializeField] private Questions _questions;
    [SerializeField] private List<Balloon> _balloons;
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private Player _player;
    [SerializeField] private EndGamePopup _endGamePopup;
    
    private int _currentIndex;
    private int _scoreCount;
    private int _answersTries;
    private bool _isGamePaused;
    private bool _isPlayerGoingDown;
    private bool _needToShowEndGame;

    public void StartGame()
    {
        _scoreCount = 0;
        _answersTries = 0;
        _isGamePaused = false;
        _isPlayerGoingDown = false;
        _needToShowEndGame = false;
        _questions.ShowQuestion(_currentIndex);

        for (int i = 0; i < _questions.GetQuestionsCount(); i++)
        {
            _balloons[i].SetBalloonName(_questions.GetAnswer(i));
        }
    }

    private void MoveOnToNextQuestion()
    {
        _answersTries = 0;
        _currentIndex++;

        if (_currentIndex == _questions.GetQuestionsCount())
        {
            _needToShowEndGame = true;
            return;
        }
        
        _questions.ShowQuestion(_currentIndex);
    }

    public void OnBalloonClicked(Balloon balloon)
    {
        if (_isGamePaused || _isPlayerGoingDown)
        {
            return;
        }
        
        _answersTries++;
        var balloonName = balloon.GetBalloonName();
        Debug.Log("Click On Balloon " + balloonName);
        var questionAnswer = _questions.GetAnswer(_currentIndex);
        Debug.Log("expected answer is " + questionAnswer);
        var isCorrectAnswer = questionAnswer == balloonName;
        Debug.Log("is correct " + isCorrectAnswer);

        if (isCorrectAnswer)
        {
            balloon.Explode();
            OnSuccess();
            _player.GoDown();
            _isPlayerGoingDown = true;
            MoveOnToNextQuestion();
        }
    }

    private void OnSuccess()
    {
        if (_answersTries == 1)
        {
            _scoreCount += 5;
        }
        
        if (_answersTries == 2)
        {
            _scoreCount += 2;
        }
        
        _scoreCounter.SetScore(_scoreCount);
    }

    public void SetPauseState(bool isPaused)
    {
        _isGamePaused = isPaused;
    }

    public void PlayerFinishedMovingDown()
    {
        _isPlayerGoingDown = false;

        if (_needToShowEndGame)
        {
            _endGamePopup.ShowEndGame(_scoreCount);
        }
    }
    
    
}
