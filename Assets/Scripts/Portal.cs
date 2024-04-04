using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform teleportLocation;
    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = teleportLocation.position;
    }



}
