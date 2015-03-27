using UnityEngine;
using System.Collections;

public class Bonus : MonoBehaviour
{
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player") {
			other.GetComponent<scrPlayer> ().Score += 10;
			Destroy (gameObject);
		}
	}
}
