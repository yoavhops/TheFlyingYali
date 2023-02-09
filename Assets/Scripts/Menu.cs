using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private TMP_InputField _inputFieldText;

    [SerializeField] private string _game1Code = "0001";
    [SerializeField] private string _game2Code = "0002";

    [SerializeField] private Game _game;
    
    private void Awake()
    {
        _playButton.onClick.AddListener(OnPlayClicked);
        _game.gameObject.SetActive(false);
    }

    private void Update()
    {
        var isValidGame = _inputFieldText.text == _game1Code || _inputFieldText.text == _game2Code;
        _playButton.gameObject.SetActive(isValidGame);
    }
    
    private void OnPlayClicked()
    {
        if (_inputFieldText.text == _game1Code)
        {
            StartGame1();
            return;
        }
        
        if (_inputFieldText.text == _game2Code)
        {
            StartGame2();
            return;
        }
    }

    private void StartGame1()
    {
        _game.GameType = 1;
        StartGame();
    }
    
    private void StartGame2()
    {
        _game.GameType = 2;
        StartGame();
    }

    private void StartGame()
    {
        _game.StartGame();
        _game.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
    
}
