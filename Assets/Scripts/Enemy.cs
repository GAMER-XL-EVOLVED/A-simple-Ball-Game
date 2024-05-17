using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public bool isChasing;
    public Transform playerTransform;
    public float chaseDistance = 100;
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
            Debug.Log((playerTransform.position - transform.position).magnitude.ToString());
            if ((playerTransform.position - transform.position).magnitude >= chaseDistance) // If player is further away then chase distance
            {
                isChasing = false;
            }
          


            //Move towards Player
            Vector3 directionToPlayer = (playerTransform.position - transform.position).normalized;
            transform.position += directionToPlayer * speed * Time.deltaTime;
            
        }
    }
}
      