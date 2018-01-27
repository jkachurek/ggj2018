using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoor : MonoBehaviour {
	[SerializeField]
	public bool hasLock;

	[HideInInspector]
	private bool isOpen = false;

	public void OpenDoor()
	{
		isOpen = true;
	}
	public void CloseDoor()
	{
		isOpen = false;
	}
}
