using UnityEngine;
using System.Collections;

public class MultipleTouchRotate : MonoBehaviour {
	void LateUpdate() {
		float pinchAmount = 0;
		Quaternion desiredRotation = transform.rotation;
		
		DetectTouchMovement.Calculate();
		
//		if(Mathf.Abs(DetectTouchMovement.pinchDistanceDelta) > 0) { // Zoom
//			pinchAmount = DetectTouchMovement.pinchDistanceDelta;
//		}
		
		if(Mathf.Abs(DetectTouchMovement.turnAngleDelta) > 0) { // Rotate
			Vector3 rotationDeg = Vector3.zero;
			rotationDeg.z = -DetectTouchMovement.turnAngleDelta;
			desiredRotation *= Quaternion.Euler(rotationDeg);
		}

		// Not so sure those will work
		transform.rotation = desiredRotation;
		transform.position += Vector3.forward * pinchAmount;
	}
}