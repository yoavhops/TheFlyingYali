using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetButton : MonoBehaviour
{
    [SerializeField] private Button _resetButton;
    
    private void Awake()
    {
        _resetButton.onClick.AddListener(OnPlayClicked);
    }

    private void OnPlayClicked()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
