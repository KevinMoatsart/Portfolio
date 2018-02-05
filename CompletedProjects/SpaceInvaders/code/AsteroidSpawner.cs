using UnityEngine;
using System.Collections;

//in charge of spawning all asteroids and their given randomness
public class AsteroidSpawner : MonoBehaviour
{

		public GameObject smallAsteroid;
		public GameObject medAsteroid;
		public GameObject bigAsteroid;
		private bool spawnedAsteroid = false;
		private int whichOne = 0;
		private float spawnRate = 3f;

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void FixedUpdate ()
		{
				if (spawnedAsteroid == false) {
						whichOne = Random.Range (1, 6);
						if (whichOne == 1) {
								Instantiate (bigAsteroid, transform.position, Quaternion.identity);
								spawnedAsteroid = true;
								StartCoroutine ("asteroidSpawn");
						} else if (whichOne == 2 || whichOne == 3) {
								Instantiate (medAsteroid, transform.position, Quaternion.identity);
								spawnedAsteroid = true;
								StartCoroutine ("asteroidSpawn");
						} else {
								Instantiate (smallAsteroid, transform.position, Quaternion.identity);
								spawnedAsteroid = true;
								StartCoroutine ("asteroidSpawn");
						}
				}

	
		}

		private IEnumerator asteroidSpawn ()
		{
				yield return new WaitForSeconds (spawnRate);
				spawnedAsteroid = false;

		}
}
