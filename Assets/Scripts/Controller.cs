using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour
{	
	// Public variables
	public float moveSpeed = 3.0f;
	public float gravity = 9.81f;

	private CharacterController myController;

	void Start ()
	{
		myController = gameObject.GetComponent<CharacterController>();
	}
	
	void Update ()
	{
		// Determine how much to move in the z-direction
		Vector3 movementZ = Input.GetAxis("Vertical") * Vector3.forward * moveSpeed * Time.deltaTime;

		// Determine how much to move in the x-direction
		Vector3 movementX = Input.GetAxis("Horizontal") * Vector3.right * moveSpeed * Time.deltaTime;

		// Convert combined Vector3 from local space to world space based on the position of the current gameobject (player)
		Vector3 movement = transform.TransformDirection(movementZ+movementX);
		
		// Apply gravity
		movement.y -= gravity * Time.deltaTime;

		Debug.Log ("Movement Vector = " + movement);

		// Move the character controller in the movement direction
		myController.Move(movement);
	}
}
