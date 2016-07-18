using UnityEngine;
using System.Collections;

public class PinchZoom : MonoBehaviour {
	float previousDistance;
	float zoomSpeed;
	float dragSpeed;

	void Start() {
		zoomSpeed = 0.02f;
		dragSpeed = 0.02f;
	}

	void Update() {
		if(Input.touchCount == 2 && (Input.GetTouch(0).phase == TouchPhase.Began || Input.GetTouch(1).phase == TouchPhase.Began)) {
			// Calibrate previous distance
			previousDistance = Vector2.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position);
		} else if(Input.touchCount == 2 && (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(1).phase == TouchPhase.Moved)) {
        	float distance;
            Vector2 touch1 = Input.GetTouch(0).position;
            Vector2 touch2 = Input.GetTouch(1).position;
            distance = Vector2.Distance(touch1, touch2);

            // Move camera along the y based on the distance of pinch
			float yChange = this.transform.position.y + (previousDistance - distance) * zoomSpeed;
			this.transform.position = new Vector3(this.transform.position.x, Mathf.Clamp (yChange, 2.5f, 9.0f), this.transform.position.z);
			previousDistance = distance;
      	} else if(Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved) {
			float xDragChange = this.transform.position.x + Input.GetTouch(0).deltaPosition.x * dragSpeed;
			float zDragChange = this.transform.position.z + Input.GetTouch(0).deltaPosition.y * dragSpeed;
			
			this.transform.position = new Vector3(xDragChange, this.transform.position.y, zDragChange);
		}
	}
}