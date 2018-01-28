using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
	private Dictionary<string, int> _inventory;


	// Use this for initialization
	void Start () {
		_inventory = new Dictionary<string, int>();
	}

	public void AddItem (GameObject item)
	{
		if (_inventory.ContainsKey(item.name))
			_inventory[item.name]++;
		else
			_inventory.Add(item.name, 1);
		Debug.Log(item.name + " collected!");
	}
	public void RemoveItem (string itemName)
	{
		if (_inventory.ContainsKey(itemName) && _inventory[itemName] > 0)
			_inventory[itemName]--;
		else
			Debug.Log("Not enough of " + itemName);
	}
	public bool HasItem (string itemName)
	{
		return _inventory.ContainsKey(itemName) && _inventory[itemName] > 0;
	}
}
