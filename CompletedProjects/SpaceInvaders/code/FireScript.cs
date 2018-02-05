using UnityEngine;
using System.Collections;

//controls the fire animation of the rocket
public class FireScript : MonoBehaviour {
	private bool fireDone = false;

	// Use this for initialization
	void Start () {
		Destroy(gameObject,1f);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if((other.gameObject.tag == "Obstacle" || other.gameObject.tag == "Enemy") && fireDone == false)
		{
			other.SendMessageUpwards("applyDamage",1);
			fireDone = true;
			StartCoroutine("fireWait");
		}

	}
	private IEnumerator fireWait()
	{
		yield return new WaitForSeconds(1f);
		fireDone = false;
	}
}
