using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Game _game;
    [SerializeField] private float _downSpeed = 1f;
    [SerializeField] private float _goDownTime = 1f;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    [SerializeField] private Sprite _goingDownSprite;
    
    private float _currentGoDownTime;
    private bool _needToGoDown;
    private Sprite _originalSprite;
    
    private void Awake()
    {
        _originalSprite = _spriteRenderer.sprite;
        _needToGoDown = false;
        _currentGoDownTime = 0;
    }

    private void Update()
    {
        if (_needToGoDown)
        {
            if (_currentGoDownTime > 0)
            {
                transform.position = transform.position - new Vector3(0, _downSpeed, 0) * Time.deltaTime;
                _currentGoDownTime -= Time.deltaTime;
            }
            else
            {
                FinishedGoingDown();
            }
        }
    }

    public void GoDown()
    {
        _needToGoDown = true;
        _currentGoDownTime = _goDownTime;
        _spriteRenderer.sprite = _goingDownSprite;
    }

    private void FinishedGoingDown()
    {
        _needToGoDown = false;
        _spriteRenderer.sprite = _originalSprite;
        _game.PlayerFinishedMovingDown();
    }
}
