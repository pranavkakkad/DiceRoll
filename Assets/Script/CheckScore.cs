using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckScore : MonoBehaviour {
	public Text timer;
	public Text Score;
	public Text CountDown;

	public GameObject correct;
	public GameObject notCorrect;

	private float score;
	private float finalScore;

	private float timeShown;



	void Start(){
		score = 0;
		correct.SetActive (false);
		notCorrect.SetActive (false);
	}

	public void Correct(){
		correct.SetActive (true);
	}

	public void NotCorrect(){
		notCorrect.SetActive (true);
	}

	public void BothDeactive (){
		correct.SetActive (false);
		notCorrect.SetActive (false);
	}



	public void CompareScoreLeft(){
//		Debug.Log ("CompareScoreLeft");
		int max = GameManager.Instance.Max ();
//		Debug.Log ("Max=" + max);
		if (max == GameManager.Instance.getPannel1()) {
			Debug.Log ("Pannel1 Correct");
			GameManager.Instance.IncreaseScore ();
			finalScore = score;
			StartCoroutine(CorrectCoRoutine());
		}
		else{
			StartCoroutine( NotcorrectCoRoutine() );
		}

		float timeRequired = GameManager.Instance.EndTime ();
		timeRequired /= 1000;
		Debug.Log ("Time = "+timeRequired);
		timer.text = timeRequired.ToString ();
//		GameManager.Instance.ResetStopWatch ();
		GameManager.Instance.FlushList ();
		GameManager.Instance.FlushScore ();
		DiceManager.Instance.DestroyDice ();
		DiceManager.Instance.GenerateDice ();
		}

	public void CompareScoreCenter(){
		
		int max = GameManager.Instance.Max ();
//		Debug.Log ("CompareScoreCenter");
//		Debug.Log (max);
//		Debug.Log (GameManager.Instance.getPannel2());
		if (max == GameManager.Instance.getPannel2()) {
			GameManager.Instance.IncreaseScore ();
			finalScore = score;

			Debug.Log ("Pannel2 Correct");
			StartCoroutine(CorrectCoRoutine());
		}
		else{
			StartCoroutine(NotcorrectCoRoutine());
		}

		float timeRequired = GameManager.Instance.EndTime ();
		timeRequired /= 1000;
		Debug.Log ("Time = "+timeRequired.ToString("f9"));
		timer.text = timeRequired.ToString ();
//		GameManager.Instance.ResetStopWatch ();
		GameManager.Instance.FlushList ();
		GameManager.Instance.FlushScore ();
		DiceManager.Instance.DestroyDice ();
		DiceManager.Instance.GenerateDice ();


	}

	public void CompareScoreRight(){
		int max = GameManager.Instance.Max ();
//		Debug.Log ("CompareScoreRight");
//		Debug.Log (max);
//		Debug.Log (GameManager.Instance.getPannel3());
		if (max == GameManager.Instance.getPannel3()) {
			Debug.Log ("Pannel3 Correct");
			GameManager.Instance.IncreaseScore ();
			finalScore = score;

			StartCoroutine(CorrectCoRoutine());
		}
		else{
			StartCoroutine(NotcorrectCoRoutine());
		}
		float timeRequired = GameManager.Instance.EndTime ();
		timeRequired /= 1000;
		Debug.Log ("Time = "+timeRequired);
		timer.text = timeRequired.ToString ();
//		GameManager.Instance.ResetStopWatch ();
		GameManager.Instance.FlushList ();
		GameManager.Instance.FlushScore ();
		DiceManager.Instance.DestroyDice ();
		DiceManager.Instance.GenerateDice ();


	}


	IEnumerator CorrectCoRoutine()
	{
		Correct ();
		while (timeShown < 0.8)
		{
			timeShown += Time.deltaTime;
			yield return null;
		}
		timeShown = 0;
		BothDeactive ();
	}

	IEnumerator NotcorrectCoRoutine()
	{
		NotCorrect ();
		while (timeShown < 0.8)
		{
			timeShown += Time.deltaTime;
			yield return null;
		}
		timeShown = 0;
		BothDeactive ();
	}


}
