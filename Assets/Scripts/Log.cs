using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Log : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _startPosition;

    private void Start()
    {
        _startPosition = transform.position;
    }

    private void Update()
    {
        if (_startPosition != transform.position)
            transform.Rotate(0, 0, _speed * Time.deltaTime);
    }
}
