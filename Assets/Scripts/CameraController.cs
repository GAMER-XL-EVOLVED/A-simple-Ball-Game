using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject ball;
    public Vector3 offset;
    public float cameraRotationDegrees = 0;
    public float cameraPitchDegrees = 0;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Mouse X") != 0)
        {
            cameraRotationDegrees += Input.GetAxis("Mouse X");
        }
        if (Input.GetAxis("Mouse Y") != 0)
        {
            cameraPitchDegrees -= Input.GetAxis("Mouse Y");
        }
        cameraPitchDegrees = Mathf.Clamp(cameraPitchDegrees, -25f, 45f);
        //Set the camera rotation to our stored rotation value
        transform.rotation = Quaternion.Euler(cameraPitchDegrees, cameraRotationDegrees, 0);

        //Position the camera directly onto the ball
        transform.position = ball.transform.position;

        //Move the camera backwards
        transform.position -= transform.forward * offset.y;

        //Move the camera up
        transform.position += Vector3.up * offset.z;
    }
}
