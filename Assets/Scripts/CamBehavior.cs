using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamBehavior : MonoBehaviour {

	public float RotationPause;
	public float AngleOfChange;
	//public float RotationEnd;
	public bool StartClockwize;

	private GameObject robot;
	private bool paused;
	private float pauseTimer;
	private Vector3 angles;
	private float stepCounter;
	private Camera cam;
	private bool clockwize;

	void Start () {
		paused = true;
		angles = transform.eulerAngles;
		cam = GetComponent<Camera>();
		clockwize = StartClockwize;
		robot = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 rayDir = robot.transform.position - this.transform.position;
		RaycastHit info;
		Physics.Raycast(this.transform.position, rayDir, out info ,100);
		if(info.transform == robot.transform){
			this.transform.LookAt(robot.transform, Vector3.up);
		} else if(paused){
			pauseTimer += Time.deltaTime;
			if (pauseTimer >= RotationPause){
				paused = false;
				pauseTimer = 0;
			}
		} else {
			TurnCamera(clockwize);
		}
	}

	private void TurnCamera(bool _clockwize){
		float step = (AngleOfChange)/5 * Time.deltaTime;
		stepCounter += step;		
		//reverse turn direction if counterclockwize
		if(!clockwize) step *= -1; 							
		transform.Rotate(Vector3.up, step, Space.World);
		if(stepCounter >= AngleOfChange) {
			//make sure angle is exactly what it should be.
			float setToAngle = AngleOfChange;
			if(!clockwize) setToAngle = -AngleOfChange; 			
			angles.y = angles.y + setToAngle;
			transform.eulerAngles = angles;			
			//reset everything
			clockwize = !_clockwize;
			paused = true;		
			stepCounter = 0;										
		}			
	}
}
