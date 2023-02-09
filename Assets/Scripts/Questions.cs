using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Questions : MonoBehaviour
{
    [SerializeField] private Game _game;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private List<string> _questionsForGame1;
    [SerializeField] private List<string> _answersForGame1;
    
    [SerializeField] private List<string> _questionsForGame2;
    [SerializeField] private List<string> _answersForGame2;
    
    public int GetQuestionsCount()
    {
        if (_game.GameType == 1)
        {
            return _answersForGame1.Count;
        }
        
        if (_game.GameType == 2)
        {
            return _answersForGame2.Count;
        }

        return -1;
    }

    public string GetAnswer(int questionIndex)
    {
        if (_game.GameType == 1)
        {
            return _answersForGame1[questionIndex];
        }
        
        if (_game.GameType == 2)
        {
            return _answersForGame2[questionIndex];
        }

        return "";
    }
    
    public void ShowQuestion(int questionIndexToShow)
    {
        if (_game.GameType == 1)
        {
            ShowQuestionForGame1(questionIndexToShow);
        }
        
        if (_game.GameType == 2)
        {
            ShowQuestionForGame2(questionIndexToShow);
        }
    }

    private void ShowQuestionForGame1(int questionNumber)
    {
        if (questionNumber < _questionsForGame1.Count)
        {
            _text.text = _questionsForGame1[questionNumber];
        }
    }
    
    private void ShowQuestionForGame2(int questionNumber)
    {
        if (questionNumber < _questionsForGame2.Count)
        {
            _text.text = _questionsForGame2[questionNumber];
        }
    }
}
