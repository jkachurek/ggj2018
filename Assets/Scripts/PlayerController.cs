using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	[SerializeField]
	private float speed = 5;
	// Update is called once per frame
	void Update () {
		var x = Input.GetAxis("Horizontal");
		var z = Input.GetAxis("Vertical");
		var vector = new Vector3(x, 0, z);
		transform.Translate(vector.normalized * speed * Time.deltaTime);
	}
}
