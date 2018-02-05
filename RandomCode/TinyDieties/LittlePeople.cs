using UnityEngine;
using System.Collections;

public class LittlePeople : MonoBehaviour {
	
	private float detectionRadius = 5;
	private float maxDistance = 5;
	private int weaponQuality = 1;
	public int resourceInInventory = 0;
	private int moveSpeed = 3;
	private int standFromResource = 1;
	public float collectionRate = 1;
	private bool canCollect = true;
	private bool canAttack = true;
	public int amountToCollectBeforeReturn = 10;
	public int maxInventory = 15;
	public Vector3 destination;

	public HeadQuarters mainBase;

	public job myJob;
	
	public enum job{
		LUMBERJACK,
		KNIGHT,
		MINER,
		SCOUT

	};

	public CharacterController myCharacterController;

	// Use this for initialization
	void Start () {
		myCharacterController = GetComponent<CharacterController> ();
		mainBase = GameObject.FindGameObjectWithTag ("HQ").GetComponent<HeadQuarters> ();
		destination = transform.position;
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		CheckAreaForResource ();
	
	}

	private void CheckAreaForResource()
	{
		Collider[] hits;
		hits = Physics.OverlapSphere (transform.position, detectionRadius);

		if (Vector3.Distance (transform.position, destination) < 2 && resourceInInventory <= 0) {
			StartCoroutine ("IdleAfterWander", 2);
		}


			for(int x = 0; x < hits.Length; x++)
			{
				if(hits[x].transform.tag == "Tree" && myJob == job.LUMBERJACK)
				{
					destination = hits[x].transform.position;
					Debug.Log("LOCATED TREE!");

					if(Vector3.Distance(transform.position, hits[x].transform.position) < 2 && canCollect)
					   {
						hits[x].SendMessage("GetChopped", weaponQuality);
						resourceInInventory += weaponQuality;
						canCollect = false;
						StartCoroutine("WaitToCollect");
						Debug.Log("Collected Resource!");
					}
				}

			else if(hits[x].transform.tag == "Stone" && myJob == job.MINER)
			{
				destination = hits[x].transform.position;
				Debug.Log("LOCATED STONE!");
				
				if(Vector3.Distance(transform.position, hits[x].transform.position) < 2 && canCollect)
				{
					hits[x].SendMessage("GetChopped", weaponQuality);
					resourceInInventory += weaponQuality;
					canCollect = false;
					StartCoroutine("WaitToCollect");
					Debug.Log("Collected Resource!");
				}
			}

			else if(hits[x].transform.tag == "Enemy" && myJob == job.KNIGHT)
			{
				destination = hits[x].transform.position;
				if(Vector3.Distance(hits[x].transform.position, transform.position) < 4)
				{
					hits[x].SendMessage("Stop");
					if(canAttack)
					{
						hits[x].SendMessage("ApplyDamage", weaponQuality);
						canAttack = false;
						StartCoroutine("WaitToAttack", hits[x].transform);
					}
				}

			}


		}


		if (resourceInInventory >= maxInventory || resourceInInventory >= amountToCollectBeforeReturn) {
			destination = mainBase.transform.position;
		}

		if (Vector3.Distance (mainBase.transform.position, transform.position) < 2 && myCharacterController.velocity.x == 0f) {
			Debug.Log("Depositing resource of " + myJob + " amount: " + resourceInInventory);
			DepositResources();
			resourceInInventory = 0;
		}


		ApproachDestination (destination);

	}

	public bool LeftOrRight(float otherX)
	{
		if (transform.position.x < otherX)
			return false;
		else
			return true;
	}

	public void ApproachDestination(Vector3 position)
	{
		if(LeftOrRight(position.x))
			transform.position = Vector3.MoveTowards (transform.position, new Vector3(position.x + standFromResource, transform.position.y, transform.position.z), moveSpeed * Time.deltaTime); 
		else
			transform.position = Vector3.MoveTowards (transform.position, new Vector3(position.x - standFromResource, transform.position.y, transform.position.z), moveSpeed * Time.deltaTime); 

	}

	private IEnumerator WaitToCollect()
	{
		yield return new WaitForSeconds (collectionRate);
		canCollect = true;
		Debug.Log ("Current amount of resource: " + resourceInInventory);
	}

	private IEnumerator IdleAfterWander(float _toIdle)
	{
		yield return new WaitForSeconds (_toIdle);
		Wander ();
	}

	private IEnumerator WaitToAttack(Transform _toAttack)
	{
		yield return new WaitForSeconds (1);
		canAttack = true;
		resourceInInventory += weaponQuality;
		if (_toAttack == null) {
			Wander();
		}
	}

	private void DepositResources()
	{
		mainBase.SendMessage ("ReceiveDeposit", this);
	}

	private void Wander()
	{
		float random = Random.Range (-50, 50);
		destination.x = random;
	}



}






















