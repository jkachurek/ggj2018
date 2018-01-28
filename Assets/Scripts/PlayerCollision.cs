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
		else if (other.GetComponent<SlidingDoor>() != null)
		{
			var door = other.GetComponent<SlidingDoor>();
			if (door.hasLock)
			{
				var inventory = GetComponent<Inventory>();
				if (inventory.HasItem(typeof(Key)))
				{
					var key = inventory.GetItem(typeof(Key));
					inventory.RemoveItem(key);
					door.OpenDoor();
				}
			}
			else
			{
				Debug.Log("the door is opening");
				door.OpenDoor();
			}
		}
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.GetComponent<SlidingDoor>())
		{
			Debug.Log("The door is closing");
			other.GetComponent<SlidingDoor>().CloseDoor();
		}
	}
}
