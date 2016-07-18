using UnityEngine;
using System.Collections;

public class RotationScript : MonoBehaviour {


    public float turnSpeed;
    public Transform target;

    Vector2 movement;

    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 currentPosition = target.position;

#if UNITY_EDITOR
        if (Input.GetButton("Fire1"))
        {
            Vector2 moveTowards = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            movement = moveTowards - currentPosition;
            movement.Normalize();
        }
#endif
        float targetAngle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
        target.rotation = Quaternion.Lerp(target.rotation, Quaternion.Euler(0, 0, targetAngle), turnSpeed * Time.deltaTime);
    }
}
