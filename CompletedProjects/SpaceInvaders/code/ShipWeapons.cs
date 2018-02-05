using UnityEngine;
using System.Collections;

//this class is in charge of controling input and delivery for the laser
//and rockets of the ship.
public class ShipWeapons : MonoBehaviour {

	public GameObject laser;
	public GameObject rocket;
	public GameObject fire;
	private KeyCode fireMain = KeyCode.W;
	private KeyCode fireSpecial = KeyCode.S;
	public int shotsFired = 0;
	public bool playerTwo = false;

	public int missleCount = 5;

	private bool laserShot = false;
	private bool specialShot = false;

	// Use this for initialization
	void Start () {
		if(playerTwo)
		{
			fireMain = KeyCode.UpArrow;
			fireSpecial = KeyCode.DownArrow;
		}
	
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(fireMain) && laserShot == false)
		{
			shootLaser();
			laserShot = true;
			StartCoroutine("fireRate");
		}
		if(Input.GetKeyDown(fireSpecial) && specialShot == false && missleCount > 0)
		{
			shootSpecial();
		}

	
	}
    //originally i was going to have different weapons, however, I cut development
    //and only had the rocket in game. Technically the special button is 
    //completely configurable
	private void shootSpecial()
	{
		Instantiate(rocket,new Vector3(transform.position.x,transform.position.y+3,transform.position.z),Quaternion.identity);
		specialShot = true;
		StartCoroutine("fireRateRocket");
		missleCount--;
	}

	private void shootLaser()
	{
		Instantiate(laser,new Vector3(transform.position.x,transform.position.y+3,transform.position.z),Quaternion.Euler(0,0,0));
		shotsFired++;
	}
	private IEnumerator fireRate ()
	{
		yield return new WaitForSeconds(.5f);
		laserShot = false;
	}
	private IEnumerator fireRateRocket ()
	{
		yield return new WaitForSeconds(1f);
		specialShot = false;
	}




}
