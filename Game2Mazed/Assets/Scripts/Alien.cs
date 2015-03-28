using UnityEngine;
using System.Collections;

public class Alien : MonoBehaviour
{
	public bool LeftFree;
	public bool RightFree;
	public bool UpFree;
	public bool DownFree;
	public int Speed;

	Rigidbody2D myBody;

	void Start ()
	{
		myBody = gameObject.GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate ()
	{
		// correct velocity vector
		myBody.velocity = new Vector2 (Mathf.RoundToInt (myBody.velocity.x), Mathf.RoundToInt (myBody.velocity.y));

		// if unit not move (velocity == 0)
		if (myBody.velocity.x == 0 && myBody.velocity.y == 0) { 
			RandomMove ();
		}

		// try to change move direction
		if (Vector2.Distance (myBody.position, new Vector2 (Mathf.RoundToInt (myBody.position.x), Mathf.RoundToInt (myBody.position.y))) < 0.03) {
			if (Mathf.RoundToInt (myBody.velocity.x) == 0 && (LeftFree || RightFree)) {
				if (Random.Range (0, 2) == 1)
					RandomMove ();
			}
			if (Mathf.RoundToInt (myBody.velocity.y) == 0 && (UpFree || DownFree)) {
				if (Random.Range (0, 2) == 1)
					RandomMove ();
			}

		}
	}

	void RandomMove ()
	{
		int direction = Random.Range (1, 5);
		switch (direction) {
		case 1:
			if (UpFree)
				myBody.velocity = new Vector2 (0, Random.Range (1, -1));
			break;
		case 2:
			if (RightFree)
				myBody.velocity = new Vector2 (Random.Range (1, -1), 0);
			break;
		case 3:
			if (DownFree)
				myBody.velocity = new Vector2 (0, Random.Range (0, -2));
			break;
		case 4:
			if (LeftFree)
				myBody.velocity = new Vector2 (Random.Range (0, -2), 0);
			break;
		}
	}
}

