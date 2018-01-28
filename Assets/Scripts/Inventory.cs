using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
	private List<GameObject> _inventory;


	// Use this for initialization
	void Start () {
		_inventory = new List<GameObject>();
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
	public bool HasItem (System.Type type)
	{
		return _inventory.Exists(o => o.GetType() == type);
	}
	public GameObject GetItem(System.Type type)
	{
		return _inventory.Find(o => o.GetType() == type);
	}
}
