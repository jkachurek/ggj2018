using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour {
	[SerializeField]
	public bool hasLock;
	[SerializeField]
	private GameObject innerDoor;

	[HideInInspector]
	public bool isOpen = false;

	public void OpenDoor()
	{
		Debug.Log("Door is opening");
		isOpen = true;
		innerDoor.transform.Rotate(0, 90f, 0);
	}
	public void CloseDoor()
	{
		Debug.Log("Door is closing");
		isOpen = false;
		innerDoor.transform.Rotate(0, -90f, 0);
	}

	public void Unlock()
	{
		Debug.Log("Door is being unlocked");
		hasLock = false;
	}
}
