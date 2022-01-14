using UnityEngine;
using System.Collections;

public class PlayAgain : MonoBehaviour
{
	// For calling RestartGame
	void OnCollisionEnter(Collision newCollision)
	{
		if (newCollision.gameObject.tag == "Projectile")
		{
			GameManager.gm.RestartGame();
		}
	}
}
