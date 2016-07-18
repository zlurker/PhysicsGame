using UnityEngine;
using System.Collections;

public class SingleTouchRotate : MonoBehaviour {
	/// <summary>
	/// Rotate speed
	/// </summary>
	[SerializeField]
	private float turnSpeed = 5;
	
	/// <summary>
	/// Movement
	/// </summary>
	private Vector2 movement;
    public float test;
	
	void Update() {
		Vector2 currentPosition = transform.position;

		# if UNITY_EDITOR
		if(Input.GetButton("Fire1")) {
			Vector2 moveTowards = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			
			movement = moveTowards - currentPosition;
			movement.Normalize();
		}
#endif

#if UNITY_ANDROID
		if (Input.touchCount > 0) {
			Touch touch = Input.GetTouch(0);
			
			if (touch.phase == TouchPhase.Moved) {
				Vector2 moveTowards = Camera.main.ScreenToWorldPoint(touch.position);
				
				movement = moveTowards - currentPosition;
				movement.Normalize();
			}
		}
#endif
       // test+= 0.1f; //after it +3, it will use that as a "destination"
        //get to there, and it loops again.
       // transform.position = new Vector3(Mathf.Repeat(test, 3), transform.position.y, transform.position.z);
        //Debug.Log(test);
       // Debug.Log(movement);
		float targetAngle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, targetAngle), turnSpeed * Time.deltaTime);
	}
}