using UnityEngine;
using System.Collections;

//small asteroids have the least amount of health, and also
//when destroyed they drop a random goody
public class SmallAsteroid : MonoBehaviour {
	
    //data values
	private int health = 1;
	public GameObject particles;
	private bool invulnerable = false;

	public GameObject healthPack;
	public GameObject ammoPack;
	public GameObject lifePack;
	private int whichOne = 0;
	private GameObject manager;
	
	// Use this for initialization
	void Start () {
		rigidbody2D.velocity = new Vector2(Random.Range(-6,6),Random.Range(-6,-2));
		manager = GameObject.FindGameObjectWithTag ("GameManager");
		
	}
	
	// Update is called once per frame
	void Update () {
		if(health <= 0)
		{
			particles.particleSystem.startColor = Color.grey;
			particles.particleSystem.startSize = .1f;
			Instantiate(particles,transform.position,Quaternion.identity);
			whichOne = Random.Range(0,50);
			if(whichOne == 0 || whichOne == 1)
				Instantiate(healthPack,transform.position,Quaternion.identity);
			if(whichOne == 2 || whichOne == 3)
				Instantiate(ammoPack,transform.position,Quaternion.identity);
			if(whichOne == 4)
				Instantiate(lifePack,transform.position,Quaternion.identity);
			manager.SendMessageUpwards("addScore", 1);
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

	private IEnumerator invincible ()
	{
		yield return new WaitForSeconds (1.0F);
		invulnerable = false;
	}
}
