using UnityEngine;
using System.Collections;

//controls all the main menu buttons found on screen
public class MainMenuButtons : MonoBehaviour {
    //data values
	public bool begin;
	public bool options;
	public bool exit;
	public bool mainMenu;
	public bool One;
	public bool Two;
	private GameObject manager;
	private GameManager managerScript;

	void Start()
	{
		manager = GameObject.FindGameObjectWithTag ("GameManager");
		managerScript = manager.GetComponent<GameManager> ();
		}


	void OnMouseOver(){
		//change text color
		renderer.material.color = Color.black;
		if(Input.GetMouseButtonDown(0))
		{
			//will begin level one from intro
			if (begin) {
				Application.LoadLevel(1);
			}
			else if (options) {
				print("You opened the options menu!");
			}
			else if (exit) {
				Application.Quit();
			}
			else if(mainMenu)
			{
				Application.LoadLevel(0);
			}
			else if(One)
			{
				Application.LoadLevel(2);
				managerScript.players = 1;
			}
			else if(Two)
			{
				Application.LoadLevel(2);
				managerScript.players = 2;
			}
		}
	}
	void OnMouseExit(){
		//change text color
		renderer.material.color=Color.white;
		
	}
}
