using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Spring : MonoBehaviour
{
    //public float forceMagnitude = 10f;
    public Vector3 forceDirection = Vector3.up;
    public float cooldownTime = 2f;

    public Color activeColor = Color.green;
    public Color cooldownColor = Color.red;

    private float lastActivationTime = -10f;
    private Renderer renderer;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.material.color = activeColor;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Time.time >= lastActivationTime + cooldownTime)
            {
                Rigidbody rb = other.attachedRigidbody;
                if (rb != null)
                {
                    //Vector3 force = forceDirection.normalized * forceMagnitude;
                    rb.velocity = forceDirection;
                    lastActivationTime = Time.time;
                    renderer.material.color = cooldownColor;
                    StartCoroutine(ResetColorAfterCooldown());
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Time.time >= lastActivationTime + cooldownTime)
            {
                Rigidbody rb = other.attachedRigidbody;
                if (rb != null)
                {
                    //Vector3 force = forceDirection.normalized * forceMagnitude;
                    rb.velocity = forceDirection;
                    lastActivationTime = Time.time;
                    renderer.material.color = cooldownColor;
                    StartCoroutine(ResetColorAfterCooldown());
                }
            }
        }
    }

    IEnumerator ResetColorAfterCooldown()
    {
        renderer.material.color = cooldownColor;
        yield return new WaitForSeconds(cooldownTime);
        renderer.material.color = activeColor;  
    }
}