using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTrigger : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] _effects;
    [SerializeField] private bool _startIfPlayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Cargo>())
        {
            SetEffect(_startIfPlayer);
        }
        if (other.GetComponent<Player>())
        {
            SetEffect(!_startIfPlayer);
        }
    }

    private void SetEffect(bool onStop)
    {
        for(int i = 0; i< _effects.Length; i++)
        {
            if (!onStop)
                _effects[i].Play();
            else
                _effects[i].Stop();
        }
    }
}
