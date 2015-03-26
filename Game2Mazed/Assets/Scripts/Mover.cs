using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
	public Rigidbody2D PlayerL;
	public Rigidbody2D PlayerR;
	public Rigidbody2D shot;
	public int speed;
	Vector2 shotDirection;

	void Start ()
	{
		shotDirection = new Vector2 (1f, 0);
	}

	void FixedUpdate ()
	{
		if (Mathf.Abs (Input.GetAxis ("Horizontal")) > 0) {
			if (Input.GetAxis ("Horizontal") < 0) {
				shotDirection = new Vector2 (-1f, shotDirection.y);
				PlayerL.transform.rotation = new Quaternion (0, 0, 0, 0);
				PlayerR.transform.rotation = new Quaternion (0, 180f, 0, 0);
			} else {
				shotDirection = new Vector2 (1f, shotDirection.y);
				PlayerL.transform.rotation = new Quaternion (0, 180f, 0, 0);
				PlayerR.transform.rotation = new Quaternion (0, 0, 0, 0);
			}
			PlayerL.velocity = new Vector2 (Input.GetAxis ("Horizontal") * speed, PlayerL.velocity.y);
			PlayerR.velocity = new Vector2 (-Input.GetAxis ("Horizontal") * speed, PlayerR.velocity.y);
		}
		if (Mathf.Abs (Input.GetAxis ("Vertical")) > 0) {
			if (Input.GetAxis ("Vertical") > 0) {
				shotDirection = new Vector2 (shotDirection.x, 1f);
			} else {
				shotDirection = new Vector2 (shotDirection.x, -1f);
			}
			PlayerL.velocity = new Vector2 (PlayerL.velocity.x, Input.GetAxis ("Vertical") * speed);
			PlayerR.velocity = new Vector2 (PlayerR.velocity.x, Input.GetAxis ("Vertical") * speed);
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			GameObject obj = (GameObject)Instantiate (shot, PlayerL.position, new Quaternion (0, 0, 0, 0));
			obj.GetComponent<Shot> ().Direction = shotDirection;
		}
	}
}
