using UnityEngine;
using System.Collections;

public class TargetMover : MonoBehaviour
{
	// Define the possible states through an enumeration
	public enum motionDirections {Spin, Horizontal, Vertical};
	
	// Store the state
	public motionDirections motionState = motionDirections.Horizontal;

	// Motion parameters
	public float spinSpeed = 180.0f;
	public float motionMagnitude = 0.1f;

	void Update ()
	{
		// Do the appropriate motion based on the motionState
		switch(motionState)
		{
			case motionDirections.Spin:
				// Rotate around the up axis of the gameObject
				gameObject.transform.Rotate (Vector3.up * spinSpeed * Time.deltaTime);
				break;
			
			case motionDirections.Vertical:
				// Move up and down over time
				gameObject.transform.Translate(Vector3.up * Mathf.Cos(Time.timeSinceLevelLoad) * motionMagnitude);
				break;

			case motionDirections.Horizontal:
				// Move left and right over time
				gameObject.transform.Translate(Vector3.right * Mathf.Cos(Time.timeSinceLevelLoad) * motionMagnitude);
				break;
		}
	}
}
