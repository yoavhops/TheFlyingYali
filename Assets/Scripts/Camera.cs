using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private GameObject _gameObjectToFollow;

    private Vector3 _originalOffset;
    
    private void Start()
    {
        _originalOffset = _gameObjectToFollow.transform.position - transform.position;
    }
    
    private void Update()
    {
        transform.position = _gameObjectToFollow.transform.position - _originalOffset;
    }
}
