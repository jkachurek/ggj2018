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
		if (innerDoor.transform.rotation.y == 0)
			innerDoor.transform.Rotate(0, 90, 0);
	}
	public void CloseDoor()
	{
		Debug.Log("Door is closing");
		isOpen = false;
		if (innerDoor.transform.rotation.y == 90)
			innerDoor.transform.Rotate(0, -90, 0);
	}

	public void Unlock()
	{
		Debug.Log("Door is being unlocked");
		hasLock = false;
	}
}
