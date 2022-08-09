using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pusher : MonoBehaviour
{
    protected void OnCollisionEnter(Collision collision)
    {
        Cargo cargo;
        if (collision.gameObject.TryGetComponent<Cargo>(out cargo))
            if (!cargo.IsTaked)
                AddCargo(cargo);
    }

    protected void AddCargo(Cargo newCargo)
    {
        newCargo.Take(transform);
    }
}
