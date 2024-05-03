using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    public Vector3 respawnPoint; // Vector3 is a collection of 3 numbers. Usually X,Y,Z.
    public AudioSource deathLaugh;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.transform.position = respawnPoint;
            other.GetComponent<Rigidbody>().velocity = Vector3.zero;
           if(deathLaugh != null)
            {
                deathLaugh.Play();
            }
            
        }
    }
}
