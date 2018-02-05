using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour {

	public GameManager manager;

	void Start()
	{
		manager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager>();
	}

	public void PlaySound(AudioClip _sound)
	{
		AudioSource.PlayClipAtPoint (_sound, Camera.main.transform.position);
	}

	public void Begin()
	{
		print ("You have begun the game!");
	}
	
	public void Continue()
	{
		manager.Continue ();
	}
	
	public void Options()
	{
		print ("You've opened up the options menu!");
	}
	
	public void Quit()
	{
		Application.Quit ();
	}
	
	public void GoToScene(int levelID)
	{
		AutoFade.LoadLevel (levelID,1,1,Color.black);
	}

	public void NextLevel()
	{
		AutoFade.LoadLevel(manager.currentLevel + 1,1,1,Color.black);
	}

	public void Resume()
	{
		manager.Resume ();
	}
	
	public void Save()
	{
		manager.Save ();
	}

	public void Load()
	{
		manager.Load ();
	}

	public void Reset()
	{
		manager.resetStats ();
	}

}
