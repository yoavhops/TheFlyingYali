using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    [SerializeField] private Game _game;
    [SerializeField] private Button _pauseButton;
    [SerializeField] private GameObject _pauseArea;

    private bool _isPaused = false;
    
    private void Awake()
    {
        _pauseButton.onClick.AddListener(OnPauseClicked);
    }

    public void OnPauseClicked()
    {
        _isPaused = !_isPaused;

        _game.SetPauseState(_isPaused);
        _pauseArea.SetActive(_isPaused);
        
        if (_isPaused == true)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
