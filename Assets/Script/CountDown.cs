using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour {
	public float startingTime;
	float currentTime;
	public Text CountText;
	// Use this for initialization
	void Start () {
		currentTime = startingTime;
	}
	
	void Update(){

		currentTime -=1*Time.deltaTime;
		CountText.text = currentTime.ToString("0");

		if(currentTime<0){
			currentTime=0;
			GameManager.Instance.OverGameView ();
		}
	}

	void OnEnable(){
		if (!GameManager.Instance.IsGamePause) {
			currentTime = startingTime;
		}
	}



}
