using UnityEngine;
using System.Collections;

//this class actually controls the velocity and death of a space debris
public class SpaceDebris : MonoBehaviour {
	private int health = 1;
	public GameObject particles;
	private GameObject manager;

	// Use this for initialization
	void Start () {
		rigidbody2D.velocity = new Vector2(0,-7);
		manager = GameObject.FindGameObjectWithTag ("GameManager");
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(health <= 0)
		{
			Instantiate(particles,transform.position,Quaternion.identity);
			renderer.enabled = false;
			manager.SendMessageUpwards("addScore", 1);
			Destroy(gameObject);
		}
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
	}
	void applyDamage(int damage)
	{
		health -= damage;
		print(health);

	}
}
