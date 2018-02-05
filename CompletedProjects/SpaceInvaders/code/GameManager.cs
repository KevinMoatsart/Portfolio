using UnityEngine;
using System.Collections;

//keeps track of pausing a game menus
public class GameManager : MonoBehaviour
{

		private KeyCode pauseButton = KeyCode.Escape;
		private bool paused = false;
		private int score = 0;
		public GUISkin retroText;
		private Rect scoreHud = new Rect(Screen.width/3 * 1.4f, (Screen.height/4 * .4f), 200, 100);

		public GameObject pauseBackground;
		public GameObject pausedText;

		private GameObject tempBackground;
		private GameObject tempText;
		public int players = 0;
		
		
		// Use this for initialization
		void Start ()
		{
		DontDestroyOnLoad (gameObject);
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (Input.GetKeyDown (pauseButton)) {
						if (paused == false && Application.loadedLevel == 3) {
								Time.timeScale = 0f;
								Instantiate(pauseBackground,new Vector3(.2f,-1.6f,0),Quaternion.identity);
				           		Instantiate(pausedText, new Vector3(-24,4.4f,-1),Quaternion.identity);
								paused = true;
								tempBackground = GameObject.FindGameObjectWithTag("pbg");
								tempText = GameObject.FindGameObjectWithTag("pt");
						} else if (paused == true && Application.loadedLevel == 3) {
								Destroy(tempBackground);
								Destroy(tempText);
								Time.timeScale = 1;
								paused = false;
						}
				}
	
		}

	void OnGUI()
	{
		GUI.skin = retroText;
		if(Application.loadedLevel == 3)
			GUI.Label (scoreHud, "Score: " + score, GUI.skin.GetStyle ("Lives"));
	}	

	void addScore(int add)
	{
		score += add;
	}
}
