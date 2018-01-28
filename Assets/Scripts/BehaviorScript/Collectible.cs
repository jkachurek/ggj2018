using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour {
	[SerializeField]
	private string itemName;
	[SerializeField]
	private float speed = 50;
	[SerializeField]
	private bool x = false;
	[SerializeField]
	private bool y = false;
	[SerializeField]
	private bool z = true;

	// Update is called once per frame
	void Update () {
		var rotation = new Vector3(x ? 1 : 0, y ? 1 : 0, z ? 1 : 0);
		transform.Rotate(rotation, speed * Time.deltaTime);
	}
}
