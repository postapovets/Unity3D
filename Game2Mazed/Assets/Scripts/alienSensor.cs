using UnityEngine;
using System.Collections;

public class alienSensor : MonoBehaviour
{

	Alien myParent;
	void Start ()
	{
		myParent = transform.parent.gameObject.GetComponent<Alien> ();
	}
	void OnTriggerStay2D (Collider2D other)
	{
		switch (gameObject.name) {
		case "left":
			myParent.LeftFree = false;
			break;
		case "right":
			myParent.RightFree = false;
			break;
		case "up":
			myParent.UpFree = false;
			break;
		case "down":
			myParent.DownFree = false;
			break;
		}

	}
	/*
	void OnTriggerEnter2D (Collider2D other)
	{
		switch (gameObject.name) {
		case "left":
			myParent.LeftFree = false;
			break;
		case "right":
			myParent.RightFree = false;
			break;
		case "up":
			myParent.UpFree = false;
			break;
		case "down":
			myParent.DownFree = false;
			break;
		}
	}
*/
	void OnTriggerExit2D (Collider2D other)
	{
		switch (gameObject.name) {
		case "left":
			myParent.LeftFree = true;
			break;
		case "right":
			myParent.RightFree = true;
			break;
		case "up":
			myParent.UpFree = true;
			break;
		case "down":
			myParent.DownFree = true;
			break;
		}
	}
}
