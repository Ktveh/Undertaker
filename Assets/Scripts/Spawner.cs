using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _delay;

    private float _ellapsedTime;

    private void Start()
    {
        _ellapsedTime = 0;
    }

    private void Update()
    {
        _ellapsedTime += Time.deltaTime;

        if (_ellapsedTime > _delay)
        {
            Spawn();
            _ellapsedTime = 0;
        }
    }

    private void Spawn()
    {
        Instantiate(_prefab, transform);
    }
}
