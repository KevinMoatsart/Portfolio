using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

	//access
	Rigidbody rBody;
	public Vector3 spawn;
	public Camera camera;
	public PlayerInfo playerInfo;
	public GameManager manager;
	public PlayerCombat myCombat;

	//variables
	public Vector3 toMove;
	private float xInput;
	private float yInput;
	private Quaternion toRotate;
	private string playerOneControlsH = "Horizontal";
	private string playerOneControlV = "Vertical";
	public Button[] currentButtons;
	private Button thisButton = null;

	
	//control
	public float maxSpeed = 10;
	public float acceleration = 2;
	public float jumpPower = 2;
	public float gravity = 0;
	public float rotSpeed = 5;
	private bool canJump = false;
	private bool onButton = false;

	// Use this for initialization
	void Start ()
	{
		rBody = GetComponent<Rigidbody> ();
		spawn = transform.position;
		camera = Camera.main;
		playerInfo = GetComponent<PlayerInfo> ();

		if (playerInfo.playerTwo) {
			playerOneControlsH = "P2Horizontal";
			playerOneControlV = "P2Vertical";

		}

		manager = playerInfo.manager;
		myCombat = GetComponent<PlayerCombat> ();
		GameObject[] buttons;
		buttons = GameObject.FindGameObjectsWithTag ("Button");
		if (buttons.Length > 0) {
			currentButtons [0] = buttons [0].GetComponent<Button> ();
			currentButtons [1] = buttons [1].GetComponent<Button> ();
		}
        
	}
	
	// Update is called once per frame
	void Update ()
	{
		//obtains feedback from joysticks
		xInput = Input.GetAxis (playerOneControlsH);
		yInput = Input.GetAxis (playerOneControlV);

		if (inRange (rBody.velocity.y, -.05f, .05f)) {
			canJump = true;
		} else {
			canJump = false;
		}
		//movement
		toMove = yInput * camera.transform.forward * acceleration + 
			xInput * camera.transform.right * acceleration;
		toMove.x = Mathf.Clamp (toMove.x, -20f, 20f);
		toMove.y = 0;
		toMove.z = Mathf.Clamp (toMove.z, -20f, 20f);
		while (toMove.x + toMove.z > 20) {
			toMove.x -= 1;
			toMove.z -= 1;
		}
		if (Input.GetButtonDown ("Jump") && canJump) {
			toMove.y = jumpPower;
		}
		if (inRange (rBody.velocity.x, -maxSpeed, maxSpeed)) {
			rBody.AddForce (new Vector3 (toMove.x, 0, 0));
		}
		if (inRange (rBody.velocity.z, -maxSpeed, maxSpeed)) {
			rBody.AddForce (new Vector3 (0, 0, toMove.z));
		}
		rBody.AddForce (new Vector3 (0, toMove.y, 0));

		if (transform.position.y < -5) {
			myCombat.Death ();
		}

		onButton = false;

	}

	bool inRange (float value, float minimum, float maximum)
	{
		if (value > minimum && value < maximum) {
			return true;
		} else {
			return false;
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Coin") {
			manager.ModifyPoints (1);
			Destroy (other.gameObject);
			AudioSource.PlayClipAtPoint (manager.gameSFX [0], Camera.main.transform.position);
		} else if (other.tag == "End") {
			if (!playerInfo.playerTwo) {
				if (!manager.playerTwoLevelCompleted) {
					manager.playerOneLevelCompleted = true;
					manager.playerOneCompleteText.enabled = true;
					print ("Waiting on Player Two!");
				} else {
					manager.CompletedLevel ();
					print ("You guys did it!");
				}

			} else {
				if (!manager.playerOneLevelCompleted) {
					print ("Waiting on Player One");
					manager.playerTwoCompleteText.enabled = true;
					manager.playerTwoLevelCompleted = true;
				} else {
					manager.CompletedLevel ();
					print ("You guys did it!");	

				}

			}
		} 
	}

	void OnCollisionStay (Collision other)
	{
		if (other.transform.tag == "Button") {
			thisButton = other.transform.GetComponent<Button> ();
			thisButton.status = true;
		} else if(thisButton != null)
		{
			thisButton.status = false;
		}
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.transform.tag == "Button") {
			manager.PlaySound(manager.gameSFX[2]);
		}
	}
}

