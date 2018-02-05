using UnityEngine;
using System.Collections;

//this class is in chagre of all movement, and also thrown in here is
//health and lives. In the future I would like to not throw this
//randomly in a class
public class ShipMovement : MonoBehaviour
{
    //data values
	private Vector3 cameraPos;
		private int health = 3;
		public int lives = 3;
		private Vector3 spawn;
		private int moveSpeed = 30;
		private KeyCode moveLeft = KeyCode.A;
		private KeyCode moveRight = KeyCode.D;
		private KeyCode slowFlight = KeyCode.LeftShift;
		private bool invulnerable = false;
		public bool playerTwo = false;
		private ShipWeapons weapons;
		private ParticleSystem particles;
		private float startingParticleRate;
		public GameObject deathParticles;
		public GameObject manager;

		public AudioClip getItem;
		public AudioClip getHit;
		public AudioClip playerMovingSound;

	public GameObject playerOneObject;
	public GameObject playerTwoObject;

		
	

		// Use this for initialization
		void Start ()
		{
		cameraPos = Camera.main.transform.position;
				manager = GameObject.FindGameObjectWithTag ("GameManager");
				if (playerTwo) {
						moveLeft = KeyCode.LeftArrow;
						moveRight = KeyCode.RightArrow;
						slowFlight = KeyCode.RightShift;
				}
				spawn = transform.position;
				weapons = gameObject.GetComponent<ShipWeapons> ();
				particles = gameObject.GetComponent<ParticleSystem> ();
				startingParticleRate = particles.emissionRate;

	
		}
	
		// Update is called once per frame
		void Update ()
		{

				if (Input.GetKey (moveLeft)) {
						//AudioSource.PlayClipAtPoint(playerMovingSound,cameraPos);
						rigidbody2D.velocity = new Vector2 (-moveSpeed, 0);
				} else if (Input.GetKey (moveRight)) {
						//AudioSource.PlayClipAtPoint(playerMovingSound,cameraPos);
						rigidbody2D.velocity = new Vector2 (moveSpeed, 0);
				} else {
						rigidbody2D.velocity = new Vector2 (0, 0);
				}

				if (Input.GetKey (slowFlight))
						moveSpeed = 10;
				else
						moveSpeed = 15;
	
				//When Players reaches desired (L/R)possition make him stop
				if (transform.position.x <= -30.5f)
						transform.position = new Vector3 (-30.5f, transform.position.y, transform.position.z);
				else if (transform.position.x >= 30.5f)
						transform.position = new Vector3 (30.5f, transform.position.y, transform.position.z);
		}

		void OnTriggerStay2D (Collider2D other)
		{		 
				if (!invulnerable) {
						AudioSource.PlayClipAtPoint(getHit,cameraPos);
						health--;
						invulnerable = true;
						StartCoroutine ("invincible");
						if (health <= 0)
								lives--;
				}

				if (health <= 0) {
						deathParticles.particleSystem.startColor = Color.blue;
						if (playerTwo)
								deathParticles.particleSystem.startColor = Color.red;
						gameObject.renderer.enabled = false;
						Instantiate (deathParticles, transform.position, Quaternion.identity);
						weapons.enabled = false;
						gameObject.collider2D.enabled = false;
						particles.emissionRate = 0;
						transform.position = spawn;
						StartCoroutine ("respawn");
				}

		}

		private IEnumerator invincible ()
		{
				yield return new WaitForSeconds (1.0F);
				invulnerable = false;
		}

		private IEnumerator respawn ()
		{
				if (lives <= 0) {
						StartCoroutine ("gameOver");
			
				}
				yield return new WaitForSeconds (5.0F);
				gameObject.renderer.enabled = true;
				weapons.enabled = true;
				gameObject.collider2D.enabled = true;
				particles.emissionRate = startingParticleRate;
				health = 3;
		}

		private IEnumerator gameOver ()
		{
				yield return new WaitForSeconds (3f);
				Destroy (manager.gameObject);
				Application.LoadLevel (0);
		}

		void applyDamage (int damage)
		{
				health -= damage;
				invulnerable = true;
				StartCoroutine ("invincible");
		}

		void ApplyCollectable (int collectable)
		{
		AudioSource.PlayClipAtPoint (getItem, cameraPos);
				if (collectable == 0)
						GiveHealth ();
				else if (collectable == 1) {
						GiveLife ();
				} else if (collectable == 2) {
						GiveAmmo ();
				} else if (collectable == 3) {
			DoublePlayer(playerTwo);
				}

		}

		void GiveHealth ()
		{
				if (health < 3)
						health++;
		}

		void GiveLife ()
		{
				lives++;
		}

		void GiveAmmo ()
		{
				weapons.missleCount += 2;
		}
    //unused power up
	void DoublePlayer(bool whichPlayer)
	{
		if (whichPlayer) {
			Instantiate(playerTwoObject,new Vector3(transform.position.x + 5,transform.position.y,transform.position.z),Quaternion.identity);

				} else {
			Instantiate(playerOneObject,new Vector3(transform.position.x + 5,transform.position.y,transform.position.z),Quaternion.identity);

				}
	}
}
