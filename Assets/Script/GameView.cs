using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameView : BaseView {

	public void OnPause(){
		GameManager.Instance.PauseGame ();
	}
}
