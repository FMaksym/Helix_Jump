using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlatforms : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Delete delete))
        {
            other.GetComponentInParent<Platform>().Destroyer();
        }
    }
}
