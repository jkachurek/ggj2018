using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamBehavior : MonoBehaviour {

	public float RotationPause;
	public float AngleOfChange;
	//public float RotationEnd;
	public bool Clockwize;

	private bool paused;
	private float pauseTimer;
	private Vector3 angles;
	private float stepCounter;

	void Start () {
		paused = true;
		angles = transform.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
		if(paused){
			pauseTimer += Time.deltaTime;
			if (pauseTimer >= RotationPause){
				paused = false;
				pauseTimer = 0;
			}
		} else {
			TurnCamera(Clockwize);
		}
	}

	private void TurnCamera(bool _clockwize){
		float step = (AngleOfChange)/5 * Time.deltaTime;
		stepCounter += step;		
		//reverse turn direction if counterclockwize
		if(!Clockwize) step *= -1; 							
		transform.Rotate(Vector3.up, step, Space.World);
		if(stepCounter >= AngleOfChange) {
			//make sure angle is exactly what it should be.
			float setToAngle = AngleOfChange;
			if(!Clockwize) setToAngle = -AngleOfChange; 			
			angles.y = angles.y + setToAngle;
			transform.eulerAngles = angles;			
			//reset everything
			Clockwize = !_clockwize;
			paused = true;		
			stepCounter = 0;										
		}			
	}
}
