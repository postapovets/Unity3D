using UnityEngine;
using System.Collections;

public class OnClickExplode : MonoBehaviour
{
	public GameObject explode;
	public GameObject wick;
	Vector3 mousePosition;

	void Update ()
	{
		mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		if (Input.GetMouseButtonDown (0)) {
			//tmpVect.z = 100;
			GameObject obj = (GameObject)Instantiate (explode, mousePosition, Quaternion.identity);
			obj.GetComponent<ParticleSystem> ().Play ();
			Destroy (obj, 3);
		}

		wick.transform.position = mousePosition;
	}

}
