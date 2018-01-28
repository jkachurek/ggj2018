using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour {
	[SerializeField]
	public bool hasLock;
	[SerializeField]
	private GameObject innerDoor;

	[HideInInspector]
	private bool isOpen = false;

	public void OpenDoor()
	{
		Debug.Log("Door is opening");
		isOpen = true;
		innerDoor.SetActive(false);
	}
	public void CloseDoor()
	{
		Debug.Log("Door is closing");
		isOpen = false;
		innerDoor.SetActive(true);
	}

	public void Unlock()
	{
		Debug.Log("Door is being unlocked");
		hasLock = false;
	}
}
