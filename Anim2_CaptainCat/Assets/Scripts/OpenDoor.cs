using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour
{

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player") {
			transform.parent.GetComponent<Animator> ().SetBool ("PlayerGoing", true);
		}
	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.tag == "Player") {
			transform.parent.GetComponent<Animator> ().SetBool ("PlayerGoing", false);
		}
	}
}
