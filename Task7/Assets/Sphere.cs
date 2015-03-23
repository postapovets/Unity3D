using UnityEngine;
using System.Collections;

public class Sphere : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButton (0)) {
			transform.localScale += new Vector3 (0.1f, 0.1f, 0.1f);
		}
		if (Input.GetMouseButton (1)) {
			if (transform.localScale.x > 0.1)
				transform.localScale += new Vector3 (-0.1f, -0.1f, -0.1f);
		}
		if (Input.GetMouseButton (2)) {
			transform.localScale = new Vector3 (1f, 1f, 1f);
		}
	}
}
