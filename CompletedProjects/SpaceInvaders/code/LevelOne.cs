using UnityEngine;
using System.Collections;

//very poorly designed first level, it is all completely written into a script. Creating
//a second level would be incredibly difficult
public class LevelOne : MonoBehaviour {

	private GameObject[] asteroidSpawners;
	private AsteroidSpawner asteroidSpawnerScript;
	public int asteroidSpawnRate;
	public GameObject firstAlien;
	private UFO firstAlienScript;
	public Transform moveTo;

	public GameObject playerOne;
	public GameObject playerTwo;

	private GameObject[] ufoSpawners;
	private UFOSpawner ufoSpawnerScript;
	private GameObject manager;
	private GameManager managerScript;

	public GameObject[] destroySpawns;
	public GameObject[] chargerSpawns;
	public GameObject chargerPrefab;

	public AudioClip alarmSound;
	public AudioClip findAlien;
	public AudioSource runawayMusic;
	public AudioSource asteroidMusic;

	// Use this for initialization
	void Start () {
		asteroidMusic.Play ();
		manager = GameObject.FindGameObjectWithTag ("GameManager");
		managerScript = manager.GetComponent<GameManager> ();
		asteroidSpawners = GameObject.FindGameObjectsWithTag("AsteroidSpawners");
		StartCoroutine("asteroidField");
		firstAlienScript = firstAlien.GetComponent<UFO>();
		firstAlienScript.enabled = false;
		firstAlien.collider2D.enabled = false;
		ufoSpawners = GameObject.FindGameObjectsWithTag ("UFOSpawner");

		TurnUFOs (false);
		TurnAsteroids (false);

		Instantiate (playerOne, new Vector3 (-13, -12, 0), Quaternion.identity);

		if (managerScript.players == 2) {
			Instantiate(playerTwo,new Vector3(13,-12,0),Quaternion.identity);

				}


	}

	private IEnumerator asteroidField()
	{
		//asteroid field is 90 secs
		yield return new WaitForSeconds (10f);
		AudioSource.PlayClipAtPoint (alarmSound, Camera.main.transform.position);
		TurnAsteroids (true);
		yield return new WaitForSeconds(90f); //MAKE 90
		TurnAsteroids (false);
		//asteroid field ends and alien approaches
		firstAlien.rigidbody2D.velocity = new Vector2(0,-5);//first alien is moving down
		yield return new WaitForSeconds(5f);
		asteroidMusic.Stop ();
		AudioSource.PlayClipAtPoint (findAlien, Camera.main.transform.position);
		firstAlien.rigidbody2D.velocity = new Vector2(0,0);//first alien is stopped
		yield return new WaitForSeconds(5f);
		firstAlien.collider2D.enabled = true;
		firstAlienScript.enabled = true;//alien attacks
		//alien is attacking the player
		spawnChargers (true);
		TurnUFOs (true);
		TurnAsteroids (true);
		runawayMusic.Play ();
		//more aliens join the fray
		yield return new WaitForSeconds (60f);
		destroySpawns = GameObject.FindGameObjectsWithTag ("chargerSpawner");
		TurnUFOs (false);
		TurnAsteroids (false);
		spawnChargers(false);
		runawayMusic.Stop ();
		asteroidMusic.Play ();
		//player escapes the battle
		yield return new WaitForSeconds (20f);
		Application.LoadLevel (4);
	}

	private void TurnUFOs(bool torf)
	{
		for (int x = 0; x < ufoSpawners.Length; x++) {
			ufoSpawnerScript = ufoSpawners [x].GetComponent<UFOSpawner> ();
			ufoSpawnerScript.enabled = torf;
		}

	}

	private void TurnAsteroids(bool torf)
	{
		for(int x = 0; x < asteroidSpawners.Length; x++)
		{	//asteroids stop
			asteroidSpawnerScript = asteroidSpawners[x].GetComponent<AsteroidSpawner>();
			asteroidSpawnerScript.enabled = torf;
		}
	}

	private void spawnChargers(bool torf)
	{
		for(int x = 0; x < chargerSpawns.Length; x++)
		{
			Instantiate(chargerPrefab,chargerSpawns[x].transform.position,Quaternion.identity);
			            }
		if (torf == false) {
			for(int x = 0; x < destroySpawns.Length;x++)
			{
				Destroy(destroySpawns[x].gameObject);
			}
				}
	}

}
