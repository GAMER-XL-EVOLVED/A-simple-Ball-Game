using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathPoint : MonoBehaviour
{
    public AudioSource AwfulDeathSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }
     
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("The enemy should be deleted");
        if (other.tag == "Player")
        {
            Destroy(transform.parent.gameObject);

            AudioSource.PlayClipAtPoint(AwfulDeathSound.clip, transform.position);

        }
        
    }
}
