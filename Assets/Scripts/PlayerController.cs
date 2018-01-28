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
		//_rigid.MoveRotation(Quaternion.LookRotation(new Vector3(0, rotation, 0)));
		//_inputs.x = Input.GetAxis("Horizontal");
		//_inputs.z = Input.GetAxis("Vertical");

		//if (_inputs != Vector3.zero)
		//_anim.SetBool("Walking", false);
		//else
		//_anim.SetBool("Walking", true);
	}
	private void FixedUpdate()
	{
		var movement = new Vector3(0, 0, inputY);
		_rigid.MovePosition(_rigid.position + transform.forward * inputY * moveSpeed * Time.deltaTime);
		//float movement = inputY * moveSpeed * Time.fixedDeltaTime;
		//var movement = new Vector3(inputX, 0);
		//_rigid.MovePosition(_rigid.position + movement * moveSpeed * Time.fixedDeltaTime);

		//float rotation = inputX * turnSpeed * Time.fixedDeltaTime;
		//transform.Rotate(0, rotation, 0);
	}
}
