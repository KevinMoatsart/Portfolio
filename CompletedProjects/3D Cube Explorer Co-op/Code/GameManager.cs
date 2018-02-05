using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;
using System.IO;

public class GameManager : MonoBehaviour {

	public int currentLevel = 0;

	public GameObject playerOne;
	public GameObject playerTwo;

	public int playerScore = 0;
	public int playerLives = 2;

	public bool playerOneLevelCompleted = false;
	public bool playerTwoLevelCompleted = false;
	public bool paused = false;

	public Text pointText;
	public Text livesText;
	public Text playerOneCompleteText;
	public Text playerTwoCompleteText;

	public Canvas gameplayHUD;
	public GameObject gameplayButtons;

	//AUDIO CLIPS
	public AudioClip[] gameMusic;
	public AudioClip[] gameSFX;


	// Use this for initialization
	void Start () {
		if (GameObject.FindGameObjectsWithTag ("GameManager").Length > 1) {
			Destroy(gameObject);
		}
		DontDestroyOnLoad (this.gameObject);

		if (gameplayHUD == null) {
		//gameplayHUD = Instantiate(Resources.Load("Gameplay_HUD"),transform.position,Quaternion.identity) as Canvas;
		}

	//	gameplayHUD = GameObject.FindGameObjectWithTag ("HUD").GetComponent<Canvas>();
	//	pointText = gameplayHUD.transform.GetChild(0).GetComponent<Text>();
	//	livesText = gameplayHUD.transform.GetChild (1).GetComponent<Text> ();

		Load ();
	
	
	}

	void OnLevelWasLoaded()
	{
		if (Application.loadedLevel > 1) {
			if(gameplayHUD == null)
			//gameplayHUD = Instantiate(Resources.Load("Gameplay_HUD"),transform.position,Quaternion.identity) as Canvas;
			gameplayHUD = GameObject.FindGameObjectWithTag ("HUD").GetComponent<Canvas>();
			pointText = gameplayHUD.transform.GetChild(1).GetComponent<Text>();
			livesText = gameplayHUD.transform.GetChild(4).GetComponent<Text>();
			gameplayButtons = gameplayHUD.transform.GetChild(5).gameObject;
			playerOneCompleteText = gameplayHUD.transform.GetChild(2).GetComponent<Text>();
			playerTwoCompleteText = gameplayHUD.transform.GetChild(3).GetComponent<Text>();

			pointText.text = playerScore.ToString ();
			livesText.text = playerLives.ToString ();
			currentLevel = Application.loadedLevel;
		}

		if (Application.loadedLevel == 1) {
			Text _score = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
			_score.text = playerScore.ToString();
			Text _lives = GameObject.FindGameObjectWithTag("Lives").GetComponent<Text>();
			_lives.text = playerLives.ToString();
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Escape) && !paused) {
			paused = true;
			gameplayButtons.SetActive (true);
			Time.timeScale = 0;
		} else if(Input.GetKeyDown (KeyCode.Escape)) {
			gameplayButtons.SetActive(false);
			paused = false;
			Time.timeScale = 1;
		}
	
	}

	public void Resume()
	{
		gameplayButtons.SetActive(false);
		paused = false;
		Time.timeScale = 1;
	}
	
	public void CompletedLevel()
	{
		playerScore += 10;
		playerOneLevelCompleted = false;
		playerTwoLevelCompleted = false;
		Application.LoadLevel (1);

	}

	public void ModifyPoints(int amount)
	{
		playerScore += amount;
		pointText.text = playerScore.ToString ();
	}
	public void ModifyLives(int amount)
	{
		playerLives += amount;
		livesText.text = playerLives.ToString ();
	}

	public void UpdateStats()
	{
		pointText.text = playerScore.ToString ();
	}

	public void loadSelectedLevel(int levelToLoad)
	{
		Application.LoadLevel (levelToLoad);
	}

	public void PlaySound(AudioClip _clip)
	{
		AudioSource.PlayClipAtPoint (_clip, Camera.main.transform.position);
	}

	public void Save ()
	{
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/playerinfo.dat");
		
		PlayerData data = new PlayerData ();
		data.coins = playerScore;
		data.level = currentLevel;

		bf.Serialize (file, data);
		file.Close ();
	}
	
	public void Load ()
	{
		if (File.Exists (Application.persistentDataPath + "/playerinfo.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/playerinfo.dat", FileMode.Open);
			PlayerData data = (PlayerData)bf.Deserialize (file);
			file.Close ();
			
			playerScore = data.coins;
			currentLevel = data.level;
		}
	}

	public void Continue()
	{
		AutoFade.LoadLevel (currentLevel,1,1,Color.black);
	}
	
	public void resetStats ()
	{
		playerScore = 0;
		currentLevel = 0;
		Save ();
	}
	
}

[Serializable]
class PlayerData
{
	public int coins;
	public int level;
}
