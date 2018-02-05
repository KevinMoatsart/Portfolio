using UnityEngine;
using System.Collections;

//the biggest of the asteroids, it has 4 health and splits into smaller asteroids.
public class AsteroidBig : MonoBehaviour {

	public GameObject midAsteroids;
	public GameObject particles;

	public GameObject healthPack;
	public GameObject ammoPack;
	public GameObject lifePack;
	private int whichOne = 0;

	private int health = 4;
	private GameObject manager;

	// Use this for initialization
	void Start () {
		manager = GameObject.FindGameObjectWithTag ("GameManager");
		if(transform.position.y > 15)
			rigidbody2D.velocity = new Vector2(Random.Range(-3,3),Random.Range(-6,-2));
		else if(transform.position.x < 15)
			rigidbody2D.velocity = new Vector2(Random.Range(3,3),Random.Range(-3,-2));
		else
			rigidbody2D.velocity = new Vector2(Random.Range(-3,-6),Random.Range(-3,-2));

	}

	void Update()
	{
		if(health <= 0)
		{
			particles.particleSystem.startColor = Color.grey;
			particles.particleSystem.startSize = .3f;
			for(int x = 0; x < Random.Range(2,3);x++)
			{
				Instantiate(midAsteroids,transform.position,Quaternion.identity);
			}
			whichOne = Random.Range(0,50);
			if(whichOne == 0 || whichOne == 1)
				Instantiate(healthPack,transform.position,Quaternion.identity);
			if(whichOne == 2 || whichOne == 3)
				Instantiate(ammoPack,transform.position,Quaternion.identity);
			if(whichOne == 4)
				Instantiate(lifePack,transform.position,Quaternion.identity);
			manager.SendMessageUpwards("addScore", 5);
			Instantiate(particles,transform.position,Quaternion.identity);
			Destroy(gameObject);
		}
	}

	void applyDamage(int damage)
	{
		health-= damage;
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Obstacle" || other.gameObject.tag == "Enemy")
		{
			rigidbody2D.velocity = new Vector2(-rigidbody2D.velocity.x,rigidbody2D.velocity.y);
		}
		if(other.gameObject.tag == "Enemy")
			health--;
	}
}
