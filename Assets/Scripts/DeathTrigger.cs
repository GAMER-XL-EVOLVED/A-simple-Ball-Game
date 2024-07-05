using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    public Vector3 respawnPoint; // Vector3 is a collection of 3 numbers. Usually X,Y,Z.
    public AudioSource deathSound;
    public bool Spike = true;


    private void Start()
    {
        deathSound = GetComponent<AudioSource>();
        if(Spike == true)
        {
            deathSound.volume = 0.5f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.transform.position = respawnPoint;
            other.GetComponent<Rigidbody>().velocity = Vector3.zero;
           if(deathSound != null)
            {
                deathSound.Play();
            }
            
        }
    }
}
