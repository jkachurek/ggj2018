using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	[SerializeField]
	private float moveSpeed = 8;

	Animator anim;
	void Start(){
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
		var x = Input.GetAxis("Horizontal");
		var z = Input.GetAxis("Vertical");
		var rotateVector = new Vector3(x, 0, z);
		anim.SetBool("Walking", false);		
		if (rotateVector != Vector3.zero)
		{
			transform.rotation = Quaternion.LookRotation(rotateVector);
			transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
			anim.SetBool("Walking", true);
		}
	}
}
