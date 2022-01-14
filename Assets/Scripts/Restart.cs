using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour
{
	// For calling RestartFromBeginning
	void OnCollisionEnter(Collision newCollision)
	{
		if (newCollision.gameObject.tag == "Projectile")
		{
			GameManager.gm.RestartFromBeginning();
		}
	}
}
