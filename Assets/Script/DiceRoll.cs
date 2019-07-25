using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoll : MonoBehaviour {

	public float speed=10.0f;
	public Vector3 startPos;
	public static Vector3 diceVelocity;
	public static bool canCheck;
	public DiceSideCheck dsc;

	public Vector3 [] diceSides = new [] {new Vector3 (0f,0f,0f),new Vector3 (0f,-1f,0f),new Vector3(1f,0f,0f),
		new Vector3 (0f,0f,-1f),new Vector3 (0f,0f,1f),new Vector3 (-1f,0f,0f),new Vector3 (0f,-1f,0f)};
	private int selectedVector;
	private IEnumerator rollRoutine;
	public bool canRoll;
	Rigidbody rb;

	void OnEnable(){
		rb = GetComponent<Rigidbody> ();
		canCheck = false;
		canRoll = true;
	}
	void OnDisable(){
	
	}
	void Update(){
		DiceSpin ();


	}


	//Generate the angle by which dice needs to rotate
	void DiceSpin(){
		

		if (Input.GetKeyDown (KeyCode.Space)) {
//			DiceNumberTestScript.diceNumber = 0;


//			Debug.Log ("Number is:" + number);
//			Vector3 targetRotation = new Vector3(0f,0f,1f);
			rollRoutine = (RotateDice());
			if(canRoll)
				StartCoroutine (rollRoutine);
		}
	}



	//Rotates the dice
	IEnumerator RotateDice(){
		float i = 0;
		float rate = 1 / 1.0f;
		canRoll = false;

		Vector3 axis = (Random.Range (1, 101) < 50) ? transform.right : transform.up ;
		Quaternion startRotation = transform.rotation;
		Quaternion targetRotation = Quaternion.LookRotation( axis * 180f);

		//Debug.Log ("Executing"+gameObject + "TargetRotation" + targetRotation);
		while (i < 1) {
			i += Time.deltaTime *rate;
			transform.rotation = Quaternion.Lerp (startRotation, targetRotation,i);
			yield return 0;
			canCheck = true;
		}
		//transform.rotation = targetRotation;
		dsc.CheckNumber();
//		Debug.Log ("Final Number"+ dsc.CheckNumber()+"<>"+gameObject.name);
		//Debug.Log (canRoll);
		canRoll = true;
	
	}




//	int CheckNumber(Vector3 currPosition){
//		float bestDot = -999;
//		for (int i = 0; i < diceSides.Length; i++) {
//			
//			var valueVector = diceSides [i];
//			var worldSpaceValueVector = this.transform.localToWorldMatrix.MultiplyVector (valueVector);
//			float dot = Vector3.Dot (worldSpaceValueVector, Vector3.up);
//			if (dot > bestDot) {
//				bestDot = dot;
//				selectedVector = i;
//			}
//		}
//		return selectedVector;
//	}
//
}
