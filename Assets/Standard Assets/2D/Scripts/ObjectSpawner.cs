using UnityEngine;
using System.Collections;

public class ObjectSpawner : MonoBehaviour {
	//public playerHealth playerHealth;       // Reference to the player's heatlh.
	public GameObject[] objects;              // The enemy prefab to be spawned.
	public float spawnTime = 3f;              // How long between each spawn.
	public Transform[] spawnPoints;           // An array of the spawn points this enemy can spawn from.
	public int maxSpawnedObjects = 0;		  // set to zero for unlimited

	private int spawnedObjectsCounter = 0;

	void Start ()
	{
		// Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}


	void Spawn ()
	{
		// If the player has no health left...
/*		if (playerHealth.currentHealth <= 0f)
		{
			// ... exit the function.
			return;
		}
*/
		// Find a random index between zero and one less than the number of spawn points.
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);

		// Create an instance of the object prefab at the randomly selected spawn point's position
		// if maxSpawnedObjectsCounter is not reached
		if (maxSpawnedObjects == 0 || spawnedObjectsCounter < maxSpawnedObjects) {
			// random object determined by the objects array index
			Instantiate (objects [Random.Range(0, objects.Length)], spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
			spawnedObjectsCounter++;
		}
	}
}