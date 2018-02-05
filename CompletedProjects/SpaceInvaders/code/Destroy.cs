using UnityEngine;
using System.Collections;

//destroys an object upon creation. It has a 3 second timer
//and is used to get rid of particles
public class Destroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy(gameObject,3f);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
