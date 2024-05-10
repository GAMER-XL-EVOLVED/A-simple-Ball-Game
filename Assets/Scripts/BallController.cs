using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public AudioSource coinSound;
    public CameraController cameraController;
    public Rigidbody rigidBody;
    public float jumpForce, speed;  // a float is a decimal number
    public int jumpCount;   
    public bool readyToJump;        // bool,short for boolean,means True or False
    public int coinsCollected;      // an int is a full number
    private bool followPlatform = true;
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
            Vector3 moveDirection = Vector3.forward * speed * Time.deltaTime ;
            moveDirection = rotation * moveDirection;
            rigidBody.AddForce(moveDirection);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 moveDirection = Vector3.back * speed * Time.deltaTime ;
            moveDirection = rotation * moveDirection;
            
            rigidBody.AddForce(moveDirection);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 moveDirection = Vector3.right * speed * Time.deltaTime ;
            moveDirection = rotation * moveDirection;

            rigidBody.AddForce(moveDirection);
        }        
           
        if (Input.GetKey(KeyCode.A)) 
        {
            Vector3 moveDirection = Vector3.left * speed * Time.deltaTime ;
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
                followPlatform = false;  // Disable following the platform 
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
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            followPlatform = true;  // Re-enable following the platform
        }
        readyToJump = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            coinsCollected += 1;
            other.gameObject.SetActive(false);
            coinSound.Play();
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("MovingPlatform") && followPlatform)
        {
            Rigidbody platformRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            if (platformRigidbody != null)
            {
                rigidBody.velocity = new Vector3(rigidBody.velocity.x, platformRigidbody.velocity.y, rigidBody.velocity.z);
            }
        }
    }

}

