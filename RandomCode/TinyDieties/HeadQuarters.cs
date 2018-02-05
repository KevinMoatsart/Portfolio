using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HeadQuarters : MonoBehaviour {

	public int essense = 0;
	public int wood = 0;
	public int stone = 0;
	public int iron = 0;
	public int gold = 0;

	public Canvas baseUI;
	private Transform resourceBase;
	public Text essenceText;
	public Text woodText;
	public Text stoneText;
	public Text ironText;

	private float essenceRate = 1;
	public int essenceCreation = 1;
	public bool canSpawnEssence = true;

	public int lumberjackCost = 10;
	public int minerCost = 15;
	public int knightCost = 20;


	// Use this for initialization
	void Start () {

		baseUI = GameObject.FindGameObjectWithTag ("GameUI").GetComponent<Canvas> ();
		resourceBase = baseUI.transform.GetChild (0);
		essenceText = resourceBase.GetChild (0).GetChild (0).GetComponent<Text> ();
		woodText = resourceBase.GetChild (1).GetChild(0).GetComponent<Text> ();
		stoneText = resourceBase.GetChild (2).GetChild(0).GetComponent<Text> ();
		ironText = resourceBase.GetChild (3).GetChild(0).GetComponent<Text> ();

		StartCoroutine ("SpawnEssence");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate()
	{

	}

	public void ReceiveDeposit(LittlePeople _littleScript)
	{
		if (_littleScript.myJob == LittlePeople.job.LUMBERJACK) {
			wood += _littleScript.resourceInInventory;
		} else if (_littleScript.myJob == LittlePeople.job.MINER) {
			stone += _littleScript.resourceInInventory;
		}
	 else if (_littleScript.myJob == LittlePeople.job.KNIGHT) {
		essense += _littleScript.resourceInInventory;
			gold += Random.Range(0, 4) * _littleScript.resourceInInventory;
	}

		UpdateText ();
	}

	public void UpdateText()
	{
		essenceText.text = essense.ToString ();
		woodText.text = wood.ToString ();
		stoneText.text = stone.ToString ();
		ironText.text = iron.ToString ();
	}

	public IEnumerator SpawnEssence()
	{
		yield return new WaitForSeconds(essenceRate);
		essense += essenceCreation;
		UpdateText ();
		StartCoroutine ("SpawnEssence");
	}
}
