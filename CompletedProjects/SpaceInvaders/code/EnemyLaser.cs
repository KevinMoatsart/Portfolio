using UnityEngine;
using System.Collections;

//laser created by enemies
public class EnemyLaser : MonoBehaviour {

	public AudioClip hit;

	// Use this for initialization
	void Start () {
		rigidbody2D.velocity = new Vector2(0,-20);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		AudioSource.PlayClipAtPoint (hit, Camera.main.transform.position);
		if(other.gameObject.tag != "Player")
			other.SendMessageUpwards("applyDamage", 1f);
		Destroy(gameObject,.01f);
	}
}
