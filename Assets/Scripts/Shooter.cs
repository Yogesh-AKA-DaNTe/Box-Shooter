using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour
{
	// Reference to projectile prefab to shoot
	public GameObject projectile;
	public float power = 10.0f;
	
	// Reference to AudioClip to play
	public AudioClip shootSFX;
	
	void Update ()
	{
		// Detect if fire button is pressed
		if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Jump"))
		{	
			// If projectile is specified
			if (projectile)
			{
				// Instantiante projectile at the camera + 1 meter forward with camera rotation
				GameObject newProjectile = Instantiate(projectile, transform.position + transform.forward, transform.rotation) as GameObject;

				// If the projectile does not have a rigidbody component, add one
				if (!newProjectile.GetComponent<Rigidbody>()) 
				{
					newProjectile.AddComponent<Rigidbody>();
				}

				// Apply force to the newProjectile's Rigidbody component if it has one
				newProjectile.GetComponent<Rigidbody>().AddForce(transform.forward * power, ForceMode.VelocityChange);
				
				// Play sound effect if set
				if (shootSFX)
				{
					if (newProjectile.GetComponent<AudioSource> ())
					{
						newProjectile.GetComponent<AudioSource> ().PlayOneShot (shootSFX);
					}
					else
					{
						AudioSource.PlayClipAtPoint (shootSFX, newProjectile.transform.position);
					}
				}
			}
		}
	}
}
