using UnityEngine;
using System.Collections;

public class MouseLooker : MonoBehaviour
{
	// Initialization variables
	public float XSensitivity = 2f;
	public float YSensitivity = 2f;
	public bool clampVerticalRotation = true;
	public float MinimumX = -90F;
	public float MaximumX = 90F;
	public bool smooth;
	public float smoothTime = 5f;
	
	// Internal private variables
	private Quaternion m_CharacterTargetRot;
	private Quaternion m_CameraTargetRot;
	private Transform character;
	private Transform cameraTransform;

	void Start()
	{
		// Start the game with the cursor locked
		LockCursor (true);

		// Get a reference to the character's transform
		character = gameObject.transform;

		// Get a reference to the main camera's transform
		cameraTransform = Camera.main.transform;

		// Get the location and rotation of the character and the camera
		m_CharacterTargetRot = character.localRotation;
		m_CameraTargetRot = cameraTransform.localRotation;
	}
	
	void Update()
	{
		// Rotate stuff based on the mouse
		LookRotation ();

		// If ESCAPE key is pressed, then unlock the cursor
		if(Input.GetButtonDown("Cancel"))
		{
			LockCursor (false);
		}

		// If the player fires, then relock the cursor
		if(Input.GetButtonDown("Fire1"))
		{
			LockCursor (true);
		}
	}
	
	// Function for locking and unlocking the cursor
	private void LockCursor(bool isLocked)
	{
		if (isLocked) 
		{
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
		}
		else
		{
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
	}

	// Function for looking with mouse
	public void LookRotation()
	{
		// Get the y and x rotation based on the Input manager
		float yRot = Input.GetAxis("Mouse X") * XSensitivity;
		float xRot = Input.GetAxis("Mouse Y") * YSensitivity;

		// Calculate the rotation
		m_CharacterTargetRot *= Quaternion.Euler (0f, yRot, 0f);
		m_CameraTargetRot *= Quaternion.Euler (-xRot, 0f, 0f);

		// Clamp the vertical rotation if specified
		if(clampVerticalRotation)
		{
			m_CameraTargetRot = ClampRotationAroundXAxis (m_CameraTargetRot);
		}

		// Update the character and camera based on calculations
		if(smooth)
		{
			// If smooth, then slerp over time
			character.localRotation = Quaternion.Slerp (character.localRotation, m_CharacterTargetRot, smoothTime * Time.deltaTime);
			cameraTransform.localRotation = Quaternion.Slerp (cameraTransform.localRotation, m_CameraTargetRot, smoothTime * Time.deltaTime);
		}
		else
		{
			// If not smooth, just jump
			character.localRotation = m_CharacterTargetRot;
			cameraTransform.localRotation = m_CameraTargetRot;
		}
	}
	
	// Math for clamping
	Quaternion ClampRotationAroundXAxis(Quaternion q)
	{
		q.x /= q.w;
		q.y /= q.w;
		q.z /= q.w;
		q.w = 1.0f;
		
		float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan (q.x);
		
		angleX = Mathf.Clamp (angleX, MinimumX, MaximumX);
		
		q.x = Mathf.Tan (0.5f * Mathf.Deg2Rad * angleX);
		
		return q;
	}
}
