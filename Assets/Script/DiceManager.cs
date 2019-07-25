using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManager : MonoBehaviour {

	public int noOfDice=6;
	public GameObject diceManagerPrefab;
	public GameObject[] diceArray;
	private float stepSizes = -3f;
	private int diceNumber;
	public bool check=false;
	public bool isRotating;
	public Transform parentObj;

	public GameObject Left;
	public GameObject Right;
	public GameObject Center;

	public static DiceManager Instance;

	void Awake(){
		Instance = this;
	}

	void OnEnable(){
//		this.setActive (false);
		diceArray = new GameObject[noOfDice];
		isRotating = false;
		GenerateDice ();
//		diceArray [0] = Instantiate (diceManagerPrefab);//, new Vector3 (0.25f,stepSize,22.3f), Quaternion.identity);
//		diceArray [0].SetActive (true);
	}

	void onDisable(){
//		PoolManager.Instance.PrefabDestroy ();
	}
	void Update(){
		if (check) {
			GameManager.Instance.CalculateScore ();
			setDisable ();
		}
	}

	public void setActive(){
		check = true;
	}

	public void setDisable(){
		check = false;
	}
	public void GenerateDice(){


			float stepSize = stepSizes;
			if (noOfDice > 9) {
				noOfDice = 9;
			}
			if (GameManager.Instance)
				GameManager.Instance.StartTime ();
			for (int i = 0; i < noOfDice; i++) {
				if (i % 3 == 0) {
					stepSize = stepSize + 2f;
					diceArray [i] = Instantiate (diceManagerPrefab, new Vector3 (-1.6f, stepSize, 22.3f), Quaternion.identity, parentObj);
					diceArray [i].SetActive (true);

				if(!isRotating && diceArray[i].activeSelf)
					diceArray [i].GetComponent<Temp> ().RotateDice ();

				}
				if (i % 3 == 1) {
					diceArray [i] = Instantiate (diceManagerPrefab, new Vector3 (0, stepSize, 22.3f), Quaternion.identity, parentObj);
					diceArray [i].SetActive (true);

				if(!isRotating && diceArray[i].activeSelf)
					diceArray [i].GetComponent<Temp> ().RotateDice ();
//				stepSize = stepSize + 2f;
				}
				if (i % 3 == 2) {
					diceArray [i] = Instantiate (diceManagerPrefab, new Vector3 (1.7f, stepSize, 22.3f), Quaternion.identity, parentObj);
					diceArray [i].SetActive (true);
				if(!isRotating && diceArray[i].activeSelf)	
				diceArray [i].GetComponent<Temp> ().RotateDice ();

					
				}
			}


	}

	public void DestroyDice(){
		
		for (int i = 0; i < noOfDice; i++) {
			Destroy (diceArray [i]);
		}
	}

	public int getNoOfDice(){
		return diceNumber;
	}

	public void ResetDice (){
		GameManager.Instance.FlushList ();
		GameManager.Instance.FlushScore ();
		DestroyDice ();
		GenerateDice ();

	}
}
