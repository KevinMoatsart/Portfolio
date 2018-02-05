using UnityEngine;
using System.Collections;

public class PlayerInfo : MonoBehaviour {

	public bool playerTwo = false;
	public int playerScore = 0;
	public int playerLives = 1;
	public Vector3 spawn;

	public GameManager manager;

	// Use this for initialization
	void Start () {
		manager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager>();
		if (playerTwo) {
			manager.playerTwo = this.gameObject;
		} else {
			manager.playerOne = this.gameObject;
		}

		spawn = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
