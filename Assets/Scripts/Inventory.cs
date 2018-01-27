using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
	private List<GameObject> _inventory;


	// Use this for initialization
	void Start () {
		_inventory = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddItem (GameObject item)
	{
		_inventory.Add(item);
		Debug.Log("Item collected!");
	}

	public void RemoveItem (GameObject item)
	{
		_inventory.Remove(item);
	}
}
