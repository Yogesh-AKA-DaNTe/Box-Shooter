using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMover : MonoBehaviour 
{
	// Motion variables
	public bool doSpin = true;
	public float spinSpeed = 180.0f;
	public bool doMotion = false;
	public float motionMagnitude = 0.1f;

	void Update () 
	{
		if (doSpin) 
		{
			gameObject.transform.Rotate (Vector3.right * spinSpeed * Time.deltaTime);
		}

		if (doMotion) 
		{
			gameObject.transform.Translate (Vector3.right * motionMagnitude * Mathf.Cos (Time.timeSinceLevelLoad));
		}
	}
}
