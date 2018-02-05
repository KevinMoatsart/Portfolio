using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ContinueButton : MonoBehaviour {

	// Use this for initialization
	void Start () {

		GameManager manager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager> ();
		if (manager.currentLevel > 0) {
			//Button continueB = GetComponent<Button>();
			//continueB.
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
