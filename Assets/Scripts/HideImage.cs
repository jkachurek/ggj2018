using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideImage : MonoBehaviour {
	public void HideSelf(){
		this.GetComponent<Image>().enabled = false;
	}
	public void ShowSelf(){
		this.GetComponent<Image>().enabled = true;	
	}
}
