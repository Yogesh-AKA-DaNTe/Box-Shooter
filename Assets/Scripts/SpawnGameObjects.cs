using UnityEngine;
using System.Collections;

public class SpawnGameObjects : MonoBehaviour
{
	// Public variables
	public float secondsBetweenSpawning = 0.1f;
	public float xMinRange = -25.0f;
	public float xMaxRange = 25.0f;
	public float yMinRange = 8.0f;
	public float yMaxRange = 25.0f;
	public float zMinRange = -25.0f;
	public float zMaxRange = 25.0f;
	public GameObject[] spawnObjects;

	private float nextSpawnTime;

	void Start ()
	{
		// Determine when to spawn the next object
		nextSpawnTime = Time.time+secondsBetweenSpawning;
	}
	
	void Update ()
	{
		// Exit if there is a game manager and the game is over
		if (GameManager.gm)
		{
			if (GameManager.gm.gameIsOver) { return; }
		}

		// If is it time to spawn a new game object
		if (Time.time  >= nextSpawnTime)
		{
			MakeThingToSpawn ();

			// Determine the next time to spawn the object
			nextSpawnTime = Time.time+secondsBetweenSpawning;
		}	
	}

	// Function to spawn
	void MakeThingToSpawn ()
	{
		Vector3 spawnPosition;

		// Get a random position between the specified ranges
		spawnPosition.x = Random.Range (xMinRange, xMaxRange);
		spawnPosition.y = Random.Range (yMinRange, yMaxRange);
		spawnPosition.z = Random.Range (zMinRange, zMaxRange);

		// Determine which object to spawn
		int objectToSpawn = Random.Range (0, spawnObjects.Length);

		// Spawn the game object
		GameObject spawnedObject = Instantiate (spawnObjects [objectToSpawn], spawnPosition, transform.rotation) as GameObject;

		// Make spawner the parent so hierarchy doesn't get messy
		spawnedObject.transform.parent = gameObject.transform;
	}
}
