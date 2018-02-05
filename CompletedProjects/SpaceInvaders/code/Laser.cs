using UnityEngine;
using System.Collections;

//controls laser and damage 
public class Laser : MonoBehaviour {

	private ShipWeapons weaponCount;
	public AudioClip laserShoot;
	public AudioClip hitObject;

	// Use this for initialization
	void Start () {
		weaponCount = GameObject.FindGameObjectWithTag("Player").GetComponent<ShipWeapons>();
		rigidbody2D.velocity = new Vector2(0,30);
		AudioSource.PlayClipAtPoint (laserShoot, Camera.main.transform.position);
		Destroy (gameObject, 2f);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		AudioSource.PlayClipAtPoint (hitObject, Camera.main.transform.position);
			other.SendMessageUpwards("applyDamage",1f);
			Destroy(gameObject,.001f);
	}
	
}
