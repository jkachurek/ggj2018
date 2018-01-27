using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour {

	// Use this for initialization
	void Start () {

        SceneManager.LoadScene("LevelTest", LoadSceneMode.Additive);
      //  this.GetComponent<Camera>().enabled = true;
      //  this.GetComponent<Camera>().gameObject.SetActive(true);



    }
	
	// Update is called once per frame
	void Update () {

     //   Debug.Log("TEST");
	}
}
