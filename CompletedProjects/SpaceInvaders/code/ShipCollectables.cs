using UnityEngine;
using System.Collections;

//unused class
public class ShipCollectables : MonoBehaviour {

    //data values
	public int playerScraps = 0;
	public int score = 0;


	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Scrap") {

			playerScraps++;
			Destroy(other.gameObject);
				}

	}

	void addScore(int points)
	{
		score += points;
	}
}
