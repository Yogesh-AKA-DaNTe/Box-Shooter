using UnityEngine;
using System.Collections;

public class TargetBehavior : MonoBehaviour
{
	public int scoreAmount = 0;
	public float timeAmount = 0.0f;

	public GameObject explosionPrefab;

	void OnCollisionEnter (Collision newCollision)
	{
		// Exit if there is a game manager and the game is over
		if (GameManager.gm)
		{
			if (GameManager.gm.gameIsOver) { return; }
		}

		if (newCollision.gameObject.tag == "Projectile")
		{
			// Instantiate explosion
			if (explosionPrefab)
			{
				Instantiate (explosionPrefab, transform.position, transform.rotation);
			}

			// If game manager exists, make adjustments based on target properties
			if (GameManager.gm)
			{
				GameManager.gm.targetHit (scoreAmount, timeAmount);
			}
				
			// Destroy the projectile
			Destroy (newCollision.gameObject);
				
			// Destroy self
			Destroy (gameObject);
		}
	}
}
