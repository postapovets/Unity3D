using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour
{
	int speed = 30;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKey (KeyCode.RightShift))
			speed = 10;
		else if (Input.GetKey (KeyCode.RightAlt))
			speed = 50;
		else
			speed = 30;
		transform.position += new Vector3 (Input.GetAxis ("HorizontalCube") / speed, Input.GetAxis ("VerticalCube") / speed, 0);
	}
}
