using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	public enum TypeOfButton
	{
		ONE,
		TWO

	};

	public TypeOfButton thisButtonType;

	public GameObject objectToEffect;
	public Button otherButton;
	public bool status = false;
	public GameManager manager;

	// Use this for initialization
	void Start () {
		manager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager> ();
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (status == true && otherButton.status == true) {
			if(objectToEffect != null)
				manager.PlaySound(manager.gameSFX[1]);
			Destroy(objectToEffect);

		}
	
	}

	public void setStatus(bool _set)
	{
		status = _set;
	}
	
}
