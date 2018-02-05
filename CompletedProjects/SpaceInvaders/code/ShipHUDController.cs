using UnityEngine;
using System.Collections;

//This class controls all the HUD that appears on the screen, displaying score
//lives, rockets, ect..
public class ShipHUDController : MonoBehaviour {

	private ShipWeapons weapons;
	private ShipMovement life;
	private ShipCollectables collectables;

	public GUISkin retroText;
	private Rect lifeHUD = new Rect ((Screen.width/4 *.9f), (Screen.height/4 * 3 * 1.2f), 200, 100) ;
	private Rect missleHud = new Rect(Screen.width/4*.9f, Screen.height/4* 3 * 1.05f,200,100);
	private Rect scoreHud = new Rect(Screen.width/4 * .4f, (Screen.height/4 * .4f), 200, 100);

	float screenWidth = Screen.width;
	float screenHeight = Screen.height;

	// Use this for initialization
	void Start () {

		weapons = gameObject.GetComponent<ShipWeapons>();
		life = gameObject.GetComponent<ShipMovement>();
		collectables = gameObject.GetComponent<ShipCollectables> ();
		if(life.playerTwo)
		{
			lifeHUD = new Rect (Screen.width/4*2.5f, Screen.height/4*3.6f, 200, 100);
			missleHud = new Rect (Screen.width/4*2.5f, Screen.height/4*3.15f, 200, 100);
		    scoreHud = new Rect(Screen.width/4 * 3.2f, (Screen.height/4 * .4f), 200, 100);
		}
	}

	void OnGUI ()
	{
		GUI.skin = retroText;
		GUI.Label (lifeHUD, "Lives: " + life.lives.ToString(), GUI.skin.GetStyle("Lives"));
		GUI.Label(missleHud,"Missles: " + weapons.missleCount.ToString(),GUI.skin.GetStyle("Lives"));
		//if(Application.loadedLevel != 3)
			//GUI.Label (scoreHud, "Score: " + collectables.score.ToString (), GUI.skin.GetStyle ("Lives"));
	}
}
