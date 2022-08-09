using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffin : MonoBehaviour
{
    [SerializeField] private Transform _coffin;
    [SerializeField] private Transform _log;
    [SerializeField] private Transform _body;
    [SerializeField] private Transform _makeUp;
    [SerializeField] private Transform _defaultFace;
    [SerializeField] private Transform _cover;
    [SerializeField] private Transform _flowers;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<CoffinTrigger>())
        {
            _coffin.gameObject.SetActive(true);
            _log.gameObject.SetActive(false);
        }

        if (other.gameObject.GetComponent<BodyTrigger>())
        {
            _body.gameObject.SetActive(true);
        }

        if (other.gameObject.GetComponent<MakeUpTrigger>())
        {
            _makeUp.gameObject.SetActive(true);
            _defaultFace.gameObject.SetActive(false);
        }

        if (other.gameObject.GetComponent<CoverTrigger>())
        {
            _cover.gameObject.SetActive(true);
        }

        if (other.gameObject.GetComponent<FlowerTrigger>())
        {
            _flowers.gameObject.SetActive(true);
        }
    }
}
