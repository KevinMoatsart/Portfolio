using UnityEngine;
using System.Collections;

//the actual charger, charges straight down and is to hard to kill
public class EnemyCharger : MonoBehaviour {

	private int moveSpeed = -15;
	private int health = 2;
	public GameObject manager;
	public GameObject particles;

	public AudioClip die;

	// Use this for initialization
	void Start () {

		manager = GameObject.FindGameObjectWithTag ("GameManager");
		rigidbody2D.velocity = new Vector2 (0, moveSpeed);
	
	}
	
	// Update is called once per frame
	void Update () {
		if(health <= 0)
		{
			AudioSource.PlayClipAtPoint(die,Camera.main.transform.position);
			Instantiate(particles,transform.position,Quaternion.identity);
			manager.SendMessageUpwards("addScore", 10);
			Destroy(gameObject);
		}
	}



	void applyDamage(int damage)
	{
		health -= damage;
	}
}
