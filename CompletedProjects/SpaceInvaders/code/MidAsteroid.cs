using UnityEngine;
using System.Collections;

//mid asteroid is the same as the small asteroid, this one simply has one more health.
//which i could use inheritance to make creating this asteroids much easier
public class MidAsteroid : MonoBehaviour {

	public GameObject smallAsteroids;
	public GameObject particles;
	private bool invulnarble = true;

	public GameObject healthPack;
	public GameObject ammoPack;
	public GameObject lifePack;
	private int whichOne = 0;
	private GameObject manager;
	
	private int health = 2;
	
	// Use this for initialization
	void Start () {
		rigidbody2D.velocity = new Vector2(Random.Range(-6,6),Random.Range(-6,-2));
		manager = GameObject.FindGameObjectWithTag ("GameManager");
		
	}

	void Update()
	{
		if(health <= 0)
		{
			particles.particleSystem.startColor = Color.grey;
			particles.particleSystem.startSize = .2f;
			for(int x = 0; x < Random.Range(2,4);x++)
			{
				Instantiate(smallAsteroids,transform.position,Quaternion.Euler(0,0,0));
			}
			whichOne = Random.Range(0,50);
			if(whichOne == 0 || whichOne == 1)
				Instantiate(healthPack,transform.position,Quaternion.identity);
			if(whichOne == 2 || whichOne == 3)
				Instantiate(ammoPack,transform.position,Quaternion.identity);
			if(whichOne == 4)
				Instantiate(lifePack,transform.position,Quaternion.identity);
			manager.SendMessageUpwards("addScore", 3);
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
