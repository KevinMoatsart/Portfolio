using UnityEngine;
using System.Collections;

public class UFO : MonoBehaviour
{

		private int health = 3;
		private int currentPosition = 0;
		private int moveSpeed = 10;
		private bool direction;
		private bool invulnerable = false;

		public GameObject particles;
		public GameObject enemyLaser;
		private GameObject manager;

		public AudioClip die;
		private int count = 0;
		
		// Use this for initialization
        //initilize values on start
		void Start ()
		{	
		manager = GameObject.FindGameObjectWithTag ("GameManager");
		rigidbody2D.velocity = new Vector2(5,-5);
		particles.particleSystem.startSize = .1f;
		}
		
		void Update()
	{   //dying animation
		if(health <= 0)
		{
			AudioSource.PlayClipAtPoint(die,Camera.main.transform.position);
			particles.particleSystem.startColor = Color.red;
			Instantiate(particles,transform.position,Quaternion.identity);
			manager.SendMessageUpwards("addScore", 7);
			Destroy(gameObject);
		}
	}

	
		// Update is called once per frame
		void FixedUpdate ()
		{
		if(direction == false)
		{
			StartCoroutine("changeDirection");
			direction = true;
		}

	}

		void applyDamage(int damage)
	{
			health -= damage;
			StartCoroutine ("invincible");
	}
    //calculate timing and direction for which way to go
	private IEnumerator changeDirection()
	{
		float moving = rigidbody2D.velocity.x;
		float movingDown = rigidbody2D.velocity.y;
		yield return new WaitForSeconds(2f);
		rigidbody2D.velocity = new Vector2(0,0);
		yield return new WaitForSeconds(.5f);
		if(transform.position.y < 15)
			Instantiate(enemyLaser,new Vector3(transform.position.x, transform.position.y - 1.5f, transform.position.z),Quaternion.identity);
		yield return new WaitForSeconds(1f);
		rigidbody2D.velocity = new Vector2(-moving,movingDown);
		direction = false;

	}
    //enemy becomes invulnerable
	private IEnumerator invincible ()
	{
		yield return new WaitForSeconds (1.0F);
		invulnerable = false;
	}
	
}
