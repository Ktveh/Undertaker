using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _leftBorder;
    [SerializeField] private float _rightBorder;

    private float _offsetPositionZ;

    private void Start()
    {
        _offsetPositionZ = transform.position.z - _target.position.z;
    }

    private void Update()
    {
        float newPositionX = _target.transform.position.x;
        if (_target.transform.position.x >= _rightBorder)
            newPositionX = _rightBorder;
        if (_target.transform.position.x <= _leftBorder)
            newPositionX = _leftBorder;
        transform.position = new Vector3(newPositionX, transform.position.y, _target.position.z + _offsetPositionZ);
        
    }
}
