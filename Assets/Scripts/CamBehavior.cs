using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamBehavior : MonoBehaviour {

	public float RotationPause;
	public float AngleOfChange;
	//public float RotationEnd;
	public bool Clockwize;
	public GameObject Robot;
	

	private bool paused;
	private float pauseTimer;
	private Vector3 angles;
	private float stepCounter;
	private Camera cam;

	void Start () {
		paused = true;
		angles = transform.eulerAngles;
		cam = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 rayDir = Robot.transform.position - this.transform.position;
		RaycastHit info;
		Physics.Raycast(this.transform.position, rayDir, out info ,100);
		if(info.transform == Robot.transform){
			this.transform.LookAt(Robot.transform, Vector3.up);
		} else if(paused){
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
