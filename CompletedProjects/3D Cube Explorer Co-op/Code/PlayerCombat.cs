using UnityEngine;
using System.Collections;

public class PlayerCombat : MonoBehaviour {

	public int health = 1;
	public int attackStrength = 0;
	public ParticleSystem deathParticles;

	public PlayerInfo playerInfo;
	public Renderer myRenderer;
	public GameManager manager;

	// Use this for initialization
	void Start () {
		//deathParticles = Resources.Load ("Death_Particles") as ParticleSystem;
		playerInfo = GetComponent<PlayerInfo> ();
		manager = playerInfo.manager;
		myRenderer = GetComponent<Renderer> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void ApplyDamage(int damage)
	{
		health -= damage;
		if (health <= 0) {
			Death();
		}
	}

	public void Death()
	{
		deathParticles.startColor = myRenderer.material.color;
		Instantiate (deathParticles, transform.position, Quaternion.identity);
		transform.position = playerInfo.spawn;
		AudioSource.PlayClipAtPoint (manager.gameSFX [2], Camera.main.transform.position);

	}

	void OnParticleCollision()
	{
		Death ();
	}
}
