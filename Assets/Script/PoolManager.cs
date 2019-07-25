using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour {
	public static PoolManager Instance;
	public int noOfDice=6;
	public GameObject diceManagerPrefab;
	public GameObject[] diceArray;

	void Awake(){
		Instance = this;
	}
	public void OnEnable(){
		diceArray = new GameObject[noOfDice];
		PrefabInit ();
	}

//	public void OnDisable(){
//		PrefabDestroy ();
//	}

	public void PrefabInit(){
		for (int i = 0; i < noOfDice; i++) {
			diceArray [i] = Instantiate (diceManagerPrefab,new Vector3(1000f,1000f,1000f),Quaternion.identity);
			diceArray [i].SetActive (false);
		}
	}
	public void PrefabDestroy(){
		for (int i = 0; i < noOfDice; i++) {
			Destroy (diceArray [i]);
		}
	}

	public void ActivateDice(int i){
		diceArray [i].SetActive (true);
	}

	public void DisableDice(int i){
		diceArray [i].SetActive (false);
	}
	public int GetNoOfDice(){
		return noOfDice;
	}
}
