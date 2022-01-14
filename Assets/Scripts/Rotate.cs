using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour
{
	// Speed rotation
	public float speed = 10.0f;

	// Setup the possible rotation states
	public enum whichWayToRotate {AroundX, AroundY, AroundZ}

	// Set the direction of the rotation
	public whichWayToRotate way = whichWayToRotate.AroundX;

	void Update ()
	{
		// Do the appropriate rotation based on the way state
		switch(way)
		{
		case whichWayToRotate.AroundX:
			transform.Rotate(Vector3.right * Time.deltaTime * speed);
			break;
		case whichWayToRotate.AroundY:
			transform.Rotate(Vector3.up * Time.deltaTime * speed);
			break;
		case whichWayToRotate.AroundZ:
			transform.Rotate(Vector3.forward * Time.deltaTime * speed);
			break;
		}	
	}
}