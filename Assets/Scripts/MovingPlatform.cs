using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Vector3 startPosition;
    public Vector3 endPosition;
    public float speed = 1.0f;
    private float startTime;
    public float journeyLength;

    void Start()
    {
        startPosition = transform.position;
        if(endPosition.x == 0)
        {
            endPosition = new Vector3(startPosition.x, endPosition.y, endPosition.z);
        }
        if (endPosition.y == 0)
        {
            endPosition = new Vector3(endPosition.x, startPosition.y, endPosition.z);
        }
        if (endPosition.z == 0)
        {
            endPosition = new Vector3(endPosition.x, endPosition.y, startPosition.z);
        }


        startTime = Time.time;
        journeyLength = Vector3.Distance(startPosition, endPosition);
    }

    //void Update()
    //{
    //    float distCovered = (Time.time - startTime) * speed;
    //    float fractionOfJourney = distCovered / journeyLength;
    //    transform.position = Vector3.Lerp(startPosition, endPosition, Mathf.PingPong(fractionOfJourney, 1));
    //}

    void FixedUpdate()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fractionOfJourney = distCovered / journeyLength;
        Vector3 newPosition = Vector3.Lerp(startPosition, endPosition, Mathf.PingPong(fractionOfJourney, 1));
        GetComponent<Rigidbody>().MovePosition(newPosition);
    }
}