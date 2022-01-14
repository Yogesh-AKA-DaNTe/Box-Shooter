using UnityEngine;
using System.Collections;

public class TargetExit : MonoBehaviour
{
	public float exitAfterSeconds = 10f;
	public float exitAnimationSeconds = 1f;

	private bool startDestroy = false;
	private float targetTime;

	void Start ()
	{
		targetTime = Time.time + exitAfterSeconds;
	}
	
	void Update ()
	{
		// Check to see if it is past the target time
		if (Time.time >= targetTime)
		{
			if (this.GetComponent<Animator> () == null)
			{
				// No Animator so just destroy right away
				Destroy (gameObject);
			}
			else if (!startDestroy)
			{
				// Set startDestroy to true so this code will not run a second time
				startDestroy = true;

				// Trigger the Animator to make the "Exit" transition
				this.GetComponent<Animator> ().SetTrigger ("Exit");

				// Call KillTarget function after exitAnimationSeconds to give time for animation to play
				Invoke ("KillTarget", exitAnimationSeconds);
			}
		}
	}

	// Destroy the gameObject when called
	void KillTarget ()
	{
		Destroy (gameObject);
	}
}
