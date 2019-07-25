using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temp : MonoBehaviour {

	public static Temp Instance;

	public List<Vector3> diceAngles;



	// Use this for initialization


//	void Update(){
//		if (Input.GetKeyDown (KeyCode.A)) {
//			RotateDice ();
//			DiceManager.Instance.setActive ();
//			//			GameManager.Instance.CalculateScore ();
//
//		}
//	}


	public void RotateDice(){
		int randomNumber = Random.Range (0, diceAngles.Count);
		if(GameManager.Instance)
		GameManager.Instance.AddScore (randomNumber + 1);
			StartCoroutine (RotateDice (diceAngles [randomNumber]));
	}

	IEnumerator RotateDice(Vector3 targetRotation){
		
		float i = 0;
		float rate = 1 / 1.0f;

		Vector3 startRotation = transform.eulerAngles;


		while (i < 1) {
			i += Time.deltaTime *rate;
			transform.eulerAngles = Vector3.Lerp (startRotation, targetRotation,i);
			yield return 0;
		}
		DiceManager.Instance.setActive ();
		DiceManager.Instance.isRotating = false;
	}
}
