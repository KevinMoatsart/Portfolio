using UnityEngine;
using System.Collections;

public class Debris : MonoBehaviour {

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.transform.tag == "Player") {
			PlayerCombat otherPlayer = other.transform.GetComponent<PlayerCombat>();
			otherPlayer.Death();
		}
	}
}
