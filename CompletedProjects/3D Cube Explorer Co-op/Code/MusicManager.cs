using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	public GameManager manager;
	public AudioClip[] gameMusic;
	public AudioSource myAudioSource;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this.gameObject);
		manager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager> ();
		myAudioSource = GetComponent<AudioSource> ();
		myAudioSource.clip = gameMusic [0];
		myAudioSource.Play ();

		if (GameObject.FindGameObjectsWithTag ("MusicManager").Length > 1) {
			Destroy(gameObject);
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnLevelWasLoaded()
	{
		transform.position = Camera.main.transform.position;
		if (Application.loadedLevel > 1 && Application.loadedLevel < 5) {
			if (myAudioSource.clip != gameMusic [1]) {
				myAudioSource.Stop ();
				myAudioSource.clip = gameMusic [1];
				myAudioSource.Play ();
				print("Boom");
			}

		} else if (Application.loadedLevel == 0) {
			myAudioSource = GetComponent<AudioSource> ();
			myAudioSource.Stop ();
			myAudioSource.clip = gameMusic [0];
			myAudioSource.Play ();
		} else if (Application.loadedLevel == 5) {
			myAudioSource.Stop();
			myAudioSource.clip = gameMusic[4];
			myAudioSource.Play();
		}
	}
}
