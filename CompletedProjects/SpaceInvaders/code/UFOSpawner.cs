using UnityEngine;
using System.Collections;

//this class controls the spawners for creating ufos.
//Based on a 3 second timer and there is a 1/3 chance that it
//will create one
public class UFOSpawner : MonoBehaviour {

    //data values
	public GameObject UFO;
	private bool spawnedUFO = false;
	private int whichOne = 0;

	// Update is called once per frame
	void FixedUpdate () {
		if(spawnedUFO == false)
		{
			whichOne = Random.Range (1, 3);
			if (whichOne == 1) {
				Instantiate (UFO, transform.position, Quaternion.Euler(0,0,180));
				spawnedUFO = true;
				StartCoroutine ("ufoSpawn");
			}
			else
			{
				spawnedUFO = true;
				StartCoroutine("ufoSpawn");
			}
		}


	
	}
	private IEnumerator ufoSpawn ()
	{
		yield return new WaitForSeconds (3f);
		spawnedUFO = false;	
	}
	
}
