using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public bool isChasing;
    public Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isChasing = true;
        }
    }
    // Update is called once per frame
    void Update()
    { 
        if (isChasing == true)
        {
            Vector3 directionToPlayer = (playerTransform.position - transform.position).normalized;
            transform.position += directionToPlayer * speed * Time.deltaTime;
            
        }
    }
}
      