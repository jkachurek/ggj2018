using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

	void Use()
	{
		GetComponent<Inventory>().RemoveItem(gameObject);
	}
}
