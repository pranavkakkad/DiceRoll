using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceSideCheck : MonoBehaviour {

	Vector3 diceVelocity;
	public int finalNumber=-1;


	// Update is called once per frame

	public static DiceSideCheck Instance;

	void Awake(){
		Instance = this;
	}

	public void CheckNumber(){
//		GameManager.Instance.AddScore (finalNumber);
//		return finalNumber;
	}

	void OnTriggerEnter(Collider col)
	{
//		Debug.Log ("Dice Side check"+ DiceRoll.canCheck);
		if(DiceRoll.canCheck) 
		{finalNumber = -1;
			
			switch (col.gameObject.name) {
			case "Side1":

				//Debug.Log ("1"+ gameObject.name);
				DiceRoll.canCheck = false;
				finalNumber = 1;
//				results.Add (finalNumber);
				break;
			case "Side2":

				//Debug.Log("2"+ gameObject.name);
				DiceRoll.canCheck = false;
				finalNumber = 2;
//				results.Add (finalNumber);
				break;
			case "Side3":

				//Debug.Log("3"+ gameObject.name);
				DiceRoll.canCheck = false;
				finalNumber = 3;
//				results.Add (finalNumber);
				break;
			case "Side4":

				//Debug.Log("4"+ gameObject.name);
				DiceRoll.canCheck = false;
				finalNumber = 4;
//				results.Add (finalNumber);
				break;
			case "Side5":

				//Debug.Log("5"+ gameObject.name);
				DiceRoll.canCheck = false;
				finalNumber = 5;
//				results.Add (finalNumber);
				break;
			case "Side6":

				//Debug.Log("6"+ gameObject.name);
				DiceRoll.canCheck = false;
				finalNumber = 6;
//				results.Add (finalNumber);
				break;
			default:
				finalNumber = -1;
				break;
			}

		}
	}


	public int ReturnScore(){
		return finalNumber;
			
//		DisplayScore.diceNumber = finalNumber;
	}


}