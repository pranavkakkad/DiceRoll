using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour {

	public static DataManager instance;

	private string HighScore = "High_Score";
	private int currentScore;


	// Use this for initialization
	void Awake () {
		instance = this;
	}



	public void setHighScore(int playerScore)
	{

		if (!PlayerPrefs.HasKey(HighScore))
		{
			PlayerPrefs.SetInt(HighScore, 0);
		}
		else{
			if (PlayerPrefs.GetInt(HighScore) < playerScore)
				PlayerPrefs.SetInt(HighScore, playerScore);
		}

	}


	public int getHighScore() {
		return PlayerPrefs.GetInt(HighScore);
	}

	public int getCurrentScore()
	{
		return currentScore;
	}
	public void setCurrentScore(int score){

		if(score > 0)
			currentScore=score;

	}

}