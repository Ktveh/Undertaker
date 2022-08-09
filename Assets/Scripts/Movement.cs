using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.Translate(Vector3.back * _speed * Time.deltaTime);
    }

    public void Stop()
    {
        _speed = 0;
    }

    public void MoveRight()
    {
        Move(-1);
    }

    public void MoveLeft()
    {
        Move(1);
    }

    public void Move(float direction)
    {
        transform.Translate(new Vector3(direction * _speed * Time.deltaTime, 0, 0));
    }
}
