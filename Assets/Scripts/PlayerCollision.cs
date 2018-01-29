using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour {
	private Inventory _inventory;

	public Sprite endGameLose;

	// Use this for initialization
	void Start () {
		_inventory = GetComponent<Inventory>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Collectible")
		{
			GetComponent<Animator>().SetTrigger("Joy");
			_inventory.AddItem(other.gameObject);
			Destroy(other.gameObject);
		}
		else if (other.GetComponent<DoorTrigger>() != null)
		{
			var door = other.GetComponent<DoorTrigger>();
			if (door.hasLock)
			{
				Debug.Log("door is locked");
				if (_inventory.HasItem("Key"))
				{
					Debug.Log("Key found, using it to unlock");
					_inventory.RemoveItem("Key");
					door.Unlock();
					door.OpenDoor();
				}
			}
			else
				door.OpenDoor();
		}
		else if (other.GetComponent<EntryExit>() != null)
		{
			if (_inventory.HasItem("Transmitter"))
			{
				_inventory.RemoveItem("Transmitter");
				Debug.Log("Game Win!");
				ShowWinScreen();
			}
			else
				Debug.Log("Come back with the transmitter");
		}
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.GetComponent<DoorTrigger>().isOpen)
			other.GetComponent<DoorTrigger>().CloseDoor();
	}

	private void ShowWinScreen()
	{
		var mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
		mainCamera.GetComponent<Game>().WinGame();
	}
}
