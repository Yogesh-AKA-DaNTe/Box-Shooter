using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour
{
	// For calling NextLevel
	void OnCollisionEnter(Collision newCollision)
	{
		if (newCollision.gameObject.tag == "Projectile")
		{
			GameManager.gm.NextLevel();
		}
	}
}
