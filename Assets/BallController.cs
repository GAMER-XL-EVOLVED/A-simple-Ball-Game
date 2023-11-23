using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Rigidbody rigidBody;
    public float jumpForce, speed;
    public int jumpCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rigidBody.AddForce(Vector3.forward * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rigidBody.AddForce(Vector3.back * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rigidBody.AddForce(Vector3.right * speed);
        }        
           
        if (Input.GetKey(KeyCode.A)) 
        {
            rigidBody.AddForce(Vector3.left * speed); 
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            if (rigidBody.velocity.y == 0)
            {
                rigidBody.AddForce(Vector3.up * jumpForce);
                jumpCount = 1;
            }
            else
            {
                if (jumpCount == 1)
                {
                     rigidBody.velocity = new Vector3(rigidBody.velocity.x, 0, rigidBody.velocity.z);
                    rigidBody.AddForce(Vector3.up * jumpForce);
                    jumpCount = 2;
                }
            }            
        }     
    }
}
