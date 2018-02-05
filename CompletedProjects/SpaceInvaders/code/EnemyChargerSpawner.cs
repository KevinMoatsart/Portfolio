using UnityEngine;
using System.Collections;

//alien that only charges forward. will spawn 3 at a time
public class EnemyChargerSpawner : MonoBehaviour {

	public GameObject charger;
	public float frequency;

	// Use this for initialization
	void Start () {
		StartCoroutine("chargerSpawn");
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		
		
		
	}
	private IEnumerator chargerSpawn ()
	{
		yield return new WaitForSeconds (frequency);
		Instantiate (charger, transform.position, Quaternion.identity);
		StartCoroutine ("chargerSpawn");
		
	}
}
