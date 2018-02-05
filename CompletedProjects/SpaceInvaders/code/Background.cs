using UnityEngine;
using System.Collections;

//this keeps the background moving, it is only 3 panels that move down
//and then back up
public class Background : MonoBehaviour {
	
	private int moveSpeed = -10;
	private Vector3 spawn;

	// Use this for initialization
	void Start () {
		rigidbody2D.velocity = new Vector2(0,moveSpeed);
		spawn = transform.position;

	
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y <= spawn.y - 30)
		{
			transform.position = spawn;
		}
	}


}
