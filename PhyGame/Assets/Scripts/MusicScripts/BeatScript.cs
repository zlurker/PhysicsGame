using UnityEngine;
using System.Collections;

public class BeatScript : MonoBehaviour {

    public Transform endingPoint;
    public float offset;

    public float startingTime;
    public float beatEndTime;

    float currentTime;
    float distToCover;
    float startY;

    void Start() {
        beatEndTime -= startingTime;
        startY = transform.position.y;
        distToCover = endingPoint.position.y - transform.position.y;
    }

    void Update() { 
        currentTime = Time.realtimeSinceStartup - offset;
        currentTime -= startingTime;

        if (currentTime < beatEndTime) {
            transform.position = new Vector3(transform.position.x, startY + ((distToCover * currentTime) / beatEndTime), transform.position.z);
        } else {
            Destroy(gameObject);
        }
    }
}
