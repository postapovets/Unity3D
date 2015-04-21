using UnityEngine;
using System.Collections;

public class nullabletypesBox : MonoBehaviour
{

	Vector3? destination = null;

	void OnTriggerEnter ()
	{
		if (destination == null) {
			destination = new Vector3 (Random.Range (-8f, 8f), 0.9f, Random.Range (-8f, 8f));
		}
	}

	void Update ()
	{
		if (destination != null) {
			transform.position = Vector3.Lerp (transform.position, destination.Value, 0.1f);
			if (Vector3.Distance (transform.position, destination.Value) < 1) {
				destination = null;
			}
		}
	}

}
