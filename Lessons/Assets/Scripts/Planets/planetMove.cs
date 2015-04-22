using UnityEngine;
using System.Collections;

public class planetMove : MonoBehaviour
{
	private float radius;
	private float angle = 0;

	public float speed = 1;


	void Start ()
	{
		radius = Mathf.Abs (Vector3.Distance (transform.position, transform.parent.transform.position));
	}

	void Update ()
	{

		transform.SetX (transform.parent.transform.position.x + radius * Mathf.Cos (angle));
		transform.SetZ (transform.parent.transform.position.z + radius * Mathf.Sin (angle));

		transform.SetY (transform.parent.transform.position.y + radius * Mathf.Sin (angle));

		angle += Mathf.PI / 120 * speed;
	}
}
