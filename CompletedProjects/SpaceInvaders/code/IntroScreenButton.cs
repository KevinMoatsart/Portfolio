using UnityEngine;
using System.Collections;

//controls buttons found on the introduction to the game
public class IntroScreenButton : MonoBehaviour {

	public bool levelOneBegin;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	}

	void OnMouseOver(){
		//change text color
		renderer.material.color = Color.green;
		if(Input.GetMouseButtonDown(0))
		{
			//will begin level one from intro
			if (levelOneBegin) {
				Application.LoadLevel(3);

		}
	}
}
	void OnMouseExit(){
		//change text color
		renderer.material.color=Color.red;
		
	}
}

