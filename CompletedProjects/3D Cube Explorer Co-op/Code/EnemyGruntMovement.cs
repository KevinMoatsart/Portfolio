using UnityEngine;
using System.Collections;

public class EnemyGruntMovement : MonoBehaviour {

	public int moveSpeed = 5;
	public int health = 1;
	public Transform[] patrolPoints;
	public int currentPoint = 0;
	public Vector3 toMove;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position != patrolPoints [currentPoint].position) {
			transform.position = Vector3.MoveTowards(transform.position,patrolPoints[currentPoint].position,moveSpeed * Time.deltaTime);
		} else if (currentPoint < patrolPoints.Length - 1) {
			currentPoint++;
		} else {
			currentPoint = 0;
            
		}
	
	}

	void OnCollisionEnter(Collision other)
	{
		if(other.transform.tag == "Player")
		{
			other.transform.SendMessageUpwards("ApplyDamage",1);
		}
	}
}
