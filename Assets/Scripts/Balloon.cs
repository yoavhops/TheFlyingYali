using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    [SerializeField] private Game _game;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite _explodeSprite;
    [SerializeField] private float _destroyTimeLeft = 0.5f;

    private bool _isExploded = false;
    
    private string _balloonName;

    public string GetBalloonName()
    {
        return _balloonName;
    }
    
    private void OnMouseUpAsButton()
    {
        _game.OnBalloonClicked(this);
    }

    public void SetBalloonName(string balloonName)
    {
        if (_game.GameType == 1)
        {
            _text.isRightToLeftText = true;
        }
        
        if (_game.GameType == 2)
        {
            _text.isRightToLeftText = false;
        }

        _balloonName = balloonName;
        _text.text = balloonName;
    }

    public void Explode()
    {
        _isExploded = true;
        _spriteRenderer.sprite = _explodeSprite;
    }

    private void Update()
    {
        if (_isExploded)
        {
            _destroyTimeLeft -= Time.deltaTime;
            if (_destroyTimeLeft < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
