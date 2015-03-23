using UnityEngine;
using System.Collections;

public class Sphere : MonoBehaviour
{
	int speed = 30;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKey (KeyCode.LeftShift))
			speed = 10;
		else if (Input.GetKey (KeyCode.LeftAlt))
			speed = 50;
		else
			speed = 30;
		transform.position += new Vector3 (Input.GetAxis ("HorizontalSphere") / speed, Input.GetAxis ("VerticalSphere") / speed, 0);
	}
}
