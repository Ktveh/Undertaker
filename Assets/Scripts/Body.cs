using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Body : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _timeOfMove;
    [SerializeField] private float _timeOfLife;
    [SerializeField] private Collider _collider;
    [SerializeField] private Animator _animator;

    private float _ellapsedTime;

    private void Start()
    {
        _ellapsedTime = 0;
    }

    private void Update()
    {
        _ellapsedTime += Time.deltaTime;
        if (_ellapsedTime > _timeOfMove)
        {
            _animator.enabled = true;
            _collider.isTrigger = true;
        }
        if (_ellapsedTime > _timeOfLife)
            gameObject.SetActive(false);

        transform.Translate(Vector3.up * _speed * Time.deltaTime);
    }
}
