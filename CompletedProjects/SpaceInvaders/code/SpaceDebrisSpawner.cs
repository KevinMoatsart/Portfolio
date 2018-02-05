using UnityEngine;
using System.Collections;

//this class contains a lot of rng. It randomly selects an asteroid based
//off a number generated, then selects a random x coordinate AND a random
//velocity
public class SpaceDebrisSpawner : MonoBehaviour
{
		private int moveSpeed = 20;
		public GameObject spaceDebris;
		private bool spawnedDebris = false;
		private int whichOne = 0;
		private bool spawnAgain = false;
		public Transform[] positions;
		private int currentPosition = 0;
		private bool tryAgain= false;
	
		// Use this for initialization
		void Start ()
		{
		
		}
	
		// Update is called once per frame
		void FixedUpdate ()
		{
		if (currentPosition >= 2)
			currentPosition = 0;
		if(spawnedDebris == false)
		{
			whichOne = Random.Range (1, 30);
				if (whichOne <= 3) {
						if (whichOne == 1) {
								for (int x = 0; x < 30; x++)
										Instantiate (spaceDebris, Random.insideUnitSphere * 7 + transform.position, Quaternion.identity);
								spawnedDebris = true;
								StartCoroutine ("asteroidSpawn");

						} else if (whichOne == 2 || whichOne == 3) {
								for (int x = 0; x < 8; x++) 
										Instantiate (spaceDebris, Random.insideUnitSphere * 3 + transform.position, Quaternion.identity);
								spawnedDebris = true;
								StartCoroutine ("asteroidSpawn");
			
						}
				}
			else
			{
				spawnedDebris = true;
				StartCoroutine("asteroidSpawn");
			}

		}
				{
						if (transform.position == positions [currentPosition].position) {
								currentPosition++;
						}
						if (currentPosition < 2)
								transform.position = Vector3.MoveTowards (transform.position, positions [currentPosition].position, moveSpeed * Time.deltaTime);

				}
		}
	
		private IEnumerator asteroidSpawn ()
		{
				yield return new WaitForSeconds (3f);
				spawnedDebris = false;
		
		}

}
