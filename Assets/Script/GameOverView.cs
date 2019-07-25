using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverView : BaseView {
	public Text highScore;
	public Text currentScore;
	public void OnPlay(){
		GameManager.Instance.StartGame ();
	}

	void OnEnable(){
		currentScore.text = DataManager.instance.getCurrentScore ().ToString();
		highScore.text = DataManager.instance.getHighScore ().ToString();
	}
}
