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
		else if (other.GetComponent<DoorTrigger>() != null)
		{
			var door = other.GetComponent<DoorTrigger>();
			if (door.hasLock)
			{
				Debug.Log("door is locked");
				var inventory = GetComponent<Inventory>();
				if (inventory.HasItem("Key"))
				{
					Debug.Log("Key found, using it to unlock");
					inventory.RemoveItem("Key");
					door.Unlock();
					door.OpenDoor();
				}
			}
			else
				door.OpenDoor();
		}
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.GetComponent<DoorTrigger>())
			other.GetComponent<DoorTrigger>().CloseDoor();
	}
}
