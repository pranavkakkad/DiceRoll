using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseView : MonoBehaviour {

	public void ShowView(){
		this.gameObject.SetActive (true);
	}
	public void HideView(){
		this.gameObject.SetActive (false);
	}
}
