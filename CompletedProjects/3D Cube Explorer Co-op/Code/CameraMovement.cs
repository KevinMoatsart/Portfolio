using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public GameManager manager;
	public Vector3 toLook;
	public Vector3 toMove;
	public Camera camera;

	public PlayerInfo playerOneInfo;
	public PlayerInfo playerTwoInfo;
	

	// Use this for initialization
	void Start () {
		manager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager> ();
		camera = Camera.main;

		playerOneInfo = manager.playerOne.GetComponent<PlayerInfo> ();
		playerTwoInfo = manager.playerTwo.GetComponent<PlayerInfo> ();

	}
	
	// Update is called once per frame
	void Update () {

		toLook = Vector3.Lerp(manager.playerOne.transform.position, manager.playerTwo.transform.position,.5f);
		transform.LookAt (toLook);

		CheckIfOnScreen (manager.playerOne);
		CheckIfOnScreen (manager.playerTwo);


	
	}

	void CheckIfOnScreen(GameObject _object)
	{
		Vector3 location;
		location = camera.WorldToViewportPoint (_object.transform.position);
		if ((location.x < 0 || location.x > 1) || (location.y < 0 || location.y > 1)) {
			//THIS SHOULD MAKE THE CAMERA MOVE BACKWARDS TO ALLOW VIEW OF BOTH PLAYERS
		}
	}
}
