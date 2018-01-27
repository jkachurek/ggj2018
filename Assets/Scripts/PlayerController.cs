using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	[SerializeField]
	private float moveSpeed = 8;
	[SerializeField]
	private float turnSpeed = 10;
	// Update is called once per frame
	void Update () {
		var x = Input.GetAxis("Horizontal");
		var z = Input.GetAxis("Vertical");
		var rotateVector = new Vector3(0, x, 0);
		transform.Translate(new Vector3(0, 0, z) * Time.deltaTime * moveSpeed);
		if (rotateVector != Vector3.zero)
		{
			transform.Rotate(rotateVector * Time.deltaTime * turnSpeed);			
		}
	}
}
