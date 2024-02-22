using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public CameraController cameraController;
    public Rigidbody rigidBody;
    public float jumpForce, speed;
    public int jumpCount;
    public bool readyToJump;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;   
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion rotation = Quaternion.Euler(0, cameraController.cameraRotationDegrees, 0);

        if (Input.GetKey(KeyCode.W))
        {
            Vector3 moveDirection = Vector3.forward * speed;
            moveDirection = rotation * moveDirection;
            rigidBody.AddForce(moveDirection);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 moveDirection = Vector3.back * speed;
            moveDirection = rotation * moveDirection;
            
            rigidBody.AddForce(moveDirection);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 moveDirection = Vector3.right * speed;
            moveDirection = rotation * moveDirection;

            rigidBody.AddForce(moveDirection);
        }        
           
        if (Input.GetKey(KeyCode.A)) 
        {
            Vector3 moveDirection = Vector3.left * speed;
            moveDirection = rotation * moveDirection;
            rigidBody.AddForce(moveDirection); 
        }

        if (Input.GetMouseButton(0))
        {
            rigidBody.velocity = Vector3.zero;
            rigidBody.angularVelocity = Vector3.zero;
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (readyToJump)
            {
                rigidBody.AddForce(Vector3.up * jumpForce);
                jumpCount = 1;
                readyToJump = false;
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

    private void OnCollisionEnter(Collision collision)
    {
        readyToJump = true;
    }
    
    
       
    }

