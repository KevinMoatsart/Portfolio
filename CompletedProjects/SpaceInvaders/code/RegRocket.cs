using UnityEngine;
using System.Collections;

//this class controls a rocket as soon as it is created
//by the player
public class RegRocket : MonoBehaviour {

	private float maxSpeed = 50;
	private float rocketRadius = 5;
	private int damage = 3;
	
	public AudioClip rocketExplosion;
	public AudioClip rocketSwoosh;

	private bool fireRespawn = false;

	private bool fireRocket;
	public GameObject fire;

	// Use this for initialization
	void Start () {
		fireRocket = true;
		AudioSource.PlayClipAtPoint (rocketSwoosh, Camera.main.transform.position);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		rigidbody2D.AddForce(new Vector2(0,40));

		if(fireRocket && fireRespawn == false)
		{
			if(transform.position.y > -15)
				Instantiate(fire,new Vector3(transform.position.x, transform.position.y - 2, 1),Quaternion.identity);
			fireRespawn = true;
			StartCoroutine("fireSpawn");
		}
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		AudioSource.PlayClipAtPoint (rocketExplosion, Camera.main.transform.position);
		Collider2D[] hitColliders = Physics2D.OverlapCircleAll(new Vector2(transform.position.x,transform.position.y),rocketRadius);
		for(int x = 0; x < hitColliders.Length; x++)
		{
			if(hitColliders[x].gameObject.tag == "Obstacle" || hitColliders[x].gameObject.tag == "Enemy")
			{
				hitColliders[x].SendMessageUpwards("applyDamage",damage);
			}
		}
		if(other.gameObject.tag != "Rocket")
		Destroy(gameObject,.01f);
	}
	private IEnumerator fireSpawn()
	{
		yield return new WaitForSeconds(.1f);
		fireRespawn = false;

	}
}
