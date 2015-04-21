using UnityEngine;
using System.Collections;

public class moonMove : MonoBehaviour
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
		transform.SetZ (radius * Mathf.Sin (angle), true);

		transform.SetY (radius * Mathf.Cos (angle), true);

		angle += Mathf.PI / 120 * speed;
	}
}
