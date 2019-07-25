using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;
using Debug=UnityEngine.Debug;

public class GameManager : MonoBehaviour {
	public static GameManager Instance;

	public GameObject HomeView;
	public GameObject GameView;
	public GameObject PauseView;
	public GameObject GameOverView;
	public List<int> Pannel =new List<int>();
	public List<int> Score =new List<int>();
	public List<int> Pannel1 =new List<int>();
	public List<int> Pannel2 =new List<int>();
	public List<int> Pannel3 =new List<int>();
	public int left;
	public int center;
	public int right;
	public float time1;
	public float previousTime;

	public Text CountText;

	public int scoring;

	public bool isPause;



	public bool ShowButton;

	public Stopwatch stopWatch;


	public enum PageState{
		None,
		HomeView,
		GameView,
		PauseView,
		GameOverView
	}

	public bool gameOver = false;

	public bool IsGamePause{
		get { return isPause;}
	}

	public bool GameOver{
		get { return gameOver;}
	}

	public void ButtonActive(){
		ShowButton = true;
	}

	public void ButtonDeActive(){
		ShowButton = false;
	}

	void Awake(){
		if (Instance != null) {
			Destroy (gameObject);
		} else {
			Instance = this;
			DontDestroyOnLoad (gameObject);
		}
	}
	void Start(){
		stopWatch = new Stopwatch ();
		StartTime ();
	}

	void OnEnable(){
		left = 0;
		center = 0;
		right = 0;
		ShowButton = false;
		scoring = 0;
		StartGame ();

	}
	void OnDisable(){
	 	CalculateScore ();
	} 

	public void StartTime(){
		stopWatch.Reset ();
		stopWatch.Start ();
	}

	public void ResetScore(){
		Debug.LogWarning ("Stage0");
		DataManager.instance.setCurrentScore (scoring);
		DataManager.instance.setHighScore (scoring);
		scoring = 0;
		CountText.text="0";
//		return scoring;

	}

	public void IncreaseScore(){
		scoring ++;
		CountText.text = scoring+"";
	}

	public float EndTime(){
		stopWatch.Stop ();
		return stopWatch.ElapsedMilliseconds;
	}


	void SetPageState(PageState state){
		switch (state) {
		case PageState.None:
			HomeView.SetActive (false);
			GameView.SetActive (false);
			PauseView.SetActive (false);
			GameOverView.SetActive (false);
			break;

		case PageState.HomeView:
			HomeView.SetActive (true);
			GameView.SetActive (false);
			PauseView.SetActive (false);
			GameOverView.SetActive (false);
			break;
		case PageState.GameView:
			HomeView.SetActive (false);
			GameView.SetActive (true);
			PauseView.SetActive (false);
			GameOverView.SetActive (false);
			break;
		case PageState.PauseView:
			HomeView.SetActive (false);
			GameView.SetActive (false);
			PauseView.SetActive (true);
			GameOverView.SetActive (false);
			break;
		case PageState.GameOverView:
			HomeView.SetActive (false);
			GameView.SetActive (false);
			PauseView.SetActive (false);
			GameOverView.SetActive (true);
			break;
		}
	}

	public void StartGame(){
		isPause = false;
		gameOver = false;
		ResetScore ();
		DiceManager.Instance.parentObj.gameObject.SetActive (false);
		SetPageState (PageState.HomeView);

	}
	public void PlayGame(){
//		isPause = false;
		gameOver = false;
		DiceManager.Instance.parentObj.gameObject.SetActive (true);
		DiceManager.Instance.ResetDice ();
		SetPageState (PageState.GameView);
	}

	public void PauseGame(){
		isPause = true;
		DiceManager.Instance.parentObj.gameObject.SetActive (false);
		SetPageState (PageState.PauseView);
	}
	public void OverGameView(){
		isPause = false;
		gameOver = true;
		Debug.LogWarning ("Stage1");
		ResetScore ();
		DiceManager.Instance.parentObj.gameObject.SetActive (false);
		SetPageState (PageState.GameOverView);
	}

	public void AddScore(int number){
		Score.Add (number);
//		CalculateScore ();
	}
	public void FlushScore(){
		Score.Clear ();
	}

	public void FlushList(){
		Pannel.Clear ();
		Pannel1.Clear ();
		Pannel2.Clear ();
		Pannel3.Clear ();
	}
	public void DisplayScore(){
		for (int i = 0; i < Score.Count; i++) {
			Debug.Log ("ScoreView " + Score [i]);
		}
	}

	public void CalculateScore(){
//		int n = DiceManager.Instance.getNoOfDice ();
		for(int i=0;i<Score.Count;i++){
//			Debug.Log ("SCore"+ Score [i]);
			if (i % 3 == 0) {
				left = left + Score [i];
			}
			if (i % 3 == 1) {
				center += Score [i];
			}
			if (i % 3 == 2) {
				right += Score [i];
			}
		}	
		Pannel.Add (left);
		Pannel.Add (center);
		Pannel.Add (right);
		Pannel1.Add (left);
		Pannel3.Add (right);
		Pannel2.Add (center);
		left = 0;
		right = 0;
		center = 0;
	}

	public int Max(){
		Pannel.Sort ();
//		Debug.Log (Pannel.Count - 1);
//		Debug.Log(Pannel [Pannel.Count - 1]);
		if (Pannel.Count != 0) {
			int max = Pannel [Pannel.Count - 1];
			return max;
		}
		return 0;
	}

	public int getPannel1(){
		return Pannel1 [0];
	}
	public int getPannel2(){
		return Pannel2 [0];
	}
	public int getPannel3(){
		return Pannel3 [0];
	}
}


