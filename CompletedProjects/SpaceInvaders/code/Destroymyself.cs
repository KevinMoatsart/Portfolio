using UnityEngine;
using System.Collections;

//kill object once it touches something
public class Destroymyself : MonoBehaviour {
	private Vector2 screenPosition;

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		Destroy(other.gameObject);
	}
}
