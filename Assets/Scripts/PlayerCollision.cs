using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {
	private Inventory _inventory;

	// Use this for initialization
	void Start () {
		_inventory = GetComponent<Inventory>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Collectible")
		{
			_inventory.AddItem(other.gameObject);
			Destroy(other.gameObject);
		}
	}
}
