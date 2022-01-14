using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicController : MonoBehaviour
{
	// Just a debug script
	void Update ()
	{
		Debug.Log ("Horizontal Input = " + Input.GetAxis ("Horizontal"));
	}
}
