using UnityEngine;
using System.Collections;

public class Alien : MonoBehaviour
{
	public bool Left;
	public bool Right;
	public bool Up;
	public bool Down;
	public int Speed;

	Rigidbody2D myBody;

	void Start ()
	{
		myBody = gameObject.GetComponent<Rigidbody2D> ();
	}

	void Update ()
	{
		if (myBody.velocity.x == 0 && myBody.velocity.y == 0) {
			myBody.velocity = new Vector2 (1 * Speed, 0 * Speed);
		}
	}
}
