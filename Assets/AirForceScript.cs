using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirForceScript : MonoBehaviour
{
    public Vector3 pushDirection;
    public float forceSpeed;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Rigidbody myRigidBody = other.GetComponent<Rigidbody>();
            myRigidBody.AddForce(pushDirection * forceSpeed);

        }
    }


}
