using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class KeyboardInput : MonoBehaviour
{
    private Movement _movement;

    private void Start()
    {
        _movement = GetComponent<Movement>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            _movement.MoveLeft();
        if (Input.GetKey(KeyCode.RightArrow))
            _movement.MoveRight();
    }
}
