using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	[SerializeField]
	private float moveSpeed = 20f;
	[SerializeField]
	private float turnSpeed = 10f;


	Quaternion targetRotation;


	private float inputX = 0f;
	private float inputY = 0f;
	

	Animator _anim;
	Rigidbody _rigid;

	void Start(){
		_anim = GetComponent<Animator>();
		_rigid = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update () {
		inputX = Input.GetAxis("Horizontal");
		inputY = Input.GetAxis("Vertical");

		float rotation = inputX * turnSpeed * Time.deltaTime;
		transform.Rotate(0, rotation, 0);
	}
	private void FixedUpdate()
	{
		if (inputY != 0)
			_anim.SetBool("Walking", true);
		else
			_anim.SetBool("Walking", false);

		var movement = new Vector3(0, 0, inputY);
		_rigid.MovePosition(_rigid.position + transform.forward * inputY * moveSpeed * Time.deltaTime);
	}
}
