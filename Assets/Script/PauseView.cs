using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseView : BaseView {
	public void OnHome(){
		GameManager.Instance.StartGame ();
	}

	public void OnResume(){
		GameManager.Instance.PlayGame ();
	}
}
