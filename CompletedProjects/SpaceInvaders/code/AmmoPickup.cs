using UnityEngine;
using System.Collections;

//gives 1 rocket
public class AmmoPickup : MonoBehaviour {

	void Start () {
		rigidbody2D.velocity = new Vector2 (0, -8);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") {
			other.SendMessageUpwards ("ApplyCollectable", 2f);
			Destroy (gameObject);
		}
	}
}
