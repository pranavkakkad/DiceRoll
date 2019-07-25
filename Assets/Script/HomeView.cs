using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeView : BaseView {

	public void OnPlay(){
		GameManager.Instance.PlayGame ();
	}
}
