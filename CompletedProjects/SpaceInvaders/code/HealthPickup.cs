using UnityEngine;
using System.Collections;

//increases health by 1
public class HealthPickup : MonoBehaviour {

	// Use this for initialization
	void Start () {
		rigidbody2D.velocity = new Vector2 (0, -8);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") {
						other.SendMessageUpwards ("ApplyCollectable", 0f);
						Destroy (gameObject);
				}
	}
}
