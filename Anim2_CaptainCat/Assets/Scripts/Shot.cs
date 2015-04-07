using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour
{
	private Vector3 startPoint;

	void Start ()
	{
		startPoint = transform.position;
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player") {
			other.GetComponent<Cat> ().Demage ();
			Destroy (gameObject);
		}
	}

	void Update ()
	{
		if (Vector3.Distance (startPoint, transform.position) > 3) {
			Destroy (gameObject);
		}
	}
}
