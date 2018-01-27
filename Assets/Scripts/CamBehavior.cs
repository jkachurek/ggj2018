using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamBehavior : MonoBehaviour {

	public float RotationPause;
	public float RotationBegin;
	public float RotationEnd;

	private bool isRotated;
	private bool paused;
	private float pauseTimer;
	private Vector3 angles;

	void Start () {
		isRotated = false;
		paused = true;
		angles = transform.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
		if(paused){
			pauseTimer += Time.deltaTime;
			if (pauseTimer >= 5){
				paused = false;
				pauseTimer = 0;
			}
		} else {
			if(isRotated == false){
				transform.Rotate(Vector3.up, Time.deltaTime * 20);
				if(transform.eulerAngles.y > 90) {
					angles.y = 90;
					transform.eulerAngles = angles;
					isRotated = true;
					paused = true;					
				}
			} else {
				transform.Rotate(Vector3.up, Time.deltaTime * -20);
				if(transform.eulerAngles.y < .5 || transform.eulerAngles.y > 359.5 ) {
					angles.y = 0;
					transform.eulerAngles = angles;
					isRotated = false;
					paused = true;					
				}			
			}
		}
	}
}
