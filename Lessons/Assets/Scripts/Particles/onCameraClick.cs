using UnityEngine;
using System.Collections;

public class onCameraClick : MonoBehaviour
{

	public GameObject explode;
	
	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) {
			explode.GetComponent<ParticleSystem> ().Play ();
		}
	}
}
