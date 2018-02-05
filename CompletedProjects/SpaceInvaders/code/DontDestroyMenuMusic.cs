using UnityEngine;
using System.Collections;

//do not destroy the menu music!
public class DontDestroyMenuMusic : MonoBehaviour {

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		if (Application.loadedLevel == 3)
						Destroy (gameObject);
	}
}
