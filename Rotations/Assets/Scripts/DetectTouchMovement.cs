using UnityEngine;
using System.Collections;

public class DetectTouchMovement : MonoBehaviour {
	const float sensitivity = 1.0f;
	const float pinchTurnRatio = Mathf.PI * sensitivity;
	const float minTurnAngle = 0.0f;
//	const float pinchRatio = 1.0f;
//	const float minPinchDistance = 0.0f;
//	const float panRatio = 1.0f;
//	const float minPanDistance = 0.0f;
	
	/// <summary>
	/// Delta angle between two touch points
	/// </summary>
	static public float turnAngleDelta;
	/// <summary>
	/// The angle between two touch points
	/// </summary>
	static public float turnAngle;
	
	/// <summary>
	/// Delta distance between two touch points that were distancing from each other
	/// </summary>
//	static public float pinchDistanceDelta;
	/// <summary>
	/// Distance between two touch points that were distancing from each other
	/// </summary>
	static public float pinchDistance;
	
	/// <summary>
	/// Calculates pinch and turn inside LateUpdate
	/// </summary>
	static public void Calculate() {
//		pinchDistance = pinchDistanceDelta = 0;
		turnAngle = turnAngleDelta = 0.0f;

		if(Input.touchCount == 2) { // Two fingers are touching the screen at the same time
			Touch touch1 = Input.touches[0];
			Touch touch2 = Input.touches[1];

			if(touch1.phase == TouchPhase.Moved || touch2.phase == TouchPhase.Moved) { // When at least one of the fingers moved
				// Check delta distance between them
				pinchDistance = Vector2.Distance(touch1.position, touch2.position);
//				float previousDistance = Vector2.Distance(touch1.position - touch1.deltaPosition, touch2.position - touch2.deltaPosition);
//				pinchDistanceDelta = pinchDistance - previousDistance;

//				if(Mathf.Abs(pinchDistanceDelta) > minPinchDistance) { // If distance is greater than minimum threshold, gesture is a pinch
//					pinchDistanceDelta *= pinchRatio;
//				} else {
//					pinchDistance = pinchDistanceDelta = 0;
//				}
				
				// Check delta angle between touches
				turnAngle = Angle(touch1.position, touch2.position);
				float previousTurn = Angle(touch1.position - touch1.deltaPosition, touch2.position - touch2.deltaPosition);
				turnAngleDelta = Mathf.DeltaAngle(previousTurn, turnAngle);
				
				// If distance is greater than minimum threshold, gesture is a turn
				if(Mathf.Abs(turnAngleDelta) > minTurnAngle) {
					turnAngleDelta *= pinchTurnRatio;
				} else {
					turnAngle = turnAngleDelta = 0;
				}
			}
		}
	}
	
	static private float Angle(Vector2 position1, Vector2 position2) {
		Vector2 from = position2 - position1;
		Vector2 to = new Vector2(1, 0);
		
		float result = Vector2.Angle(from, to);
		Vector3 cross = Vector3.Cross(from, to);
		
		if(cross.z > 0)
			result = 360.0f - result;
		
		return result;
	}
}