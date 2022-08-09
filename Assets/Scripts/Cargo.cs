using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using DG.Tweening;

public class Cargo : Pusher
{
    [SerializeField] private float _distance;
    [SerializeField] private float _speed;
    [SerializeField] private float _finishDelay;
    [SerializeField] private float _minHeight;
    [SerializeField] private Vector3 _animationScale;
    [SerializeField] private Vector3 _animationScaleLittle;
    [SerializeField] private Transform _pusher;
    [SerializeField] private bool _isTaked = false;
    [SerializeField] private Transform _finishPoint;
    [SerializeField] private BoxCollider _boxCollider;
    
    private const float AnimationDuration = 0.175f;
    private const float FinishDuration = 0.8f;

    private Vector3 _beginScale;
    private Coroutine _setPositionXJob;
    private float _oldPositionX;
    private float _newPositionX;

    public bool IsTaked => _isTaked;

    private void Start()
    {
        _beginScale = transform.localScale;
        _boxCollider.GetComponent<BoxCollider>();
    }

    private void Update()
    {
        if (_isTaked)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, _pusher.position.z + _distance);
            _newPositionX = _pusher.position.x;
            if (_newPositionX != _oldPositionX)
                StartSetPositionX(_newPositionX);
            _oldPositionX = _pusher.position.x;
        }
        else
        {
            if (transform.position.y < _minHeight)
                transform.position = new Vector3(_finishPoint.position.x, _minHeight, _finishPoint.position.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<FinishTrigger>())
            MoveToFinish();
    }

    private void OnTriggerExit(Collider other)
    {
        if (_isTaked && other.GetComponent<GameTrigger>() && transform.localScale == _beginScale)
            StartAnimation();
    }

    public void Take(Transform pusher)
    {
        _pusher = pusher;
        if (!_pusher.GetComponent<Player>())
            StartAnimation();
        transform.position = new Vector3(_pusher.position.x, transform.position.y, _pusher.position.z + _distance);
        _oldPositionX = _pusher.position.x;
        _isTaked = true;
    }

    private void StartSetPositionX(float targetValue)
    {
        if (_setPositionXJob != null)
            StopCoroutine(_setPositionXJob);
        _setPositionXJob = StartCoroutine(SetPositionX(targetValue));
    }

    private IEnumerator SetPositionX(float targetValue)
    {
        float positionX;
        while (transform.position.x != targetValue)
        {
            positionX = Mathf.MoveTowards(transform.position.x, targetValue, _speed * Time.deltaTime);
            transform.position = new Vector3(positionX, transform.position.y, transform.position.z);
            yield return null;
        }
    }

    private void StartAnimation()
    {
        int loops = 2;
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOScale(_animationScale, AnimationDuration).SetLoops(loops, LoopType.Yoyo)).Append(transform.DOScale(_animationScaleLittle, AnimationDuration).SetLoops(loops, LoopType.Yoyo));
    }

    private void MoveToFinish()
    {
        _isTaked = false;
        if (_setPositionXJob != null)
            StopCoroutine(_setPositionXJob);
        _boxCollider.enabled = false;

        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(_finishPoint.position, FinishDuration + _finishDelay)).Append(transform.DOMoveY(_minHeight, FinishDuration));
    }
}
