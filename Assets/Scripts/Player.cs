using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Pusher
{
    [SerializeField] private PlayerAnimator _animator;
    [SerializeField] private Movement _movement;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<FinishTrigger>())
        {
            _animator.StartDance();
            _movement.Stop();
        }
    }
}
