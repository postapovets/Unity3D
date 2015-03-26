using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
	public Rigidbody2D PlayerL;
	public Rigidbody2D PlayerR;
	public GameObject shot;
	public int speed;
	Vector2 shotDirection;
	SceneGenerator sceneGenerator;

	void Start ()
	{
		shotDirection = new Vector2 (1f, 0);
		//	transform.GetComponent<SceneGenerator> ().numLevel = 2; // 1 - first level
		transform.GetComponent<SceneGenerator> ().BuildLevel ();
	}

	void FixedUpdate ()
	{
		if (Mathf.Abs (Input.GetAxis ("Horizontal")) > 0) {
			if (Input.GetAxis ("Horizontal") < 0) {
				shotDirection = new Vector2 (-1f, 0);
				PlayerL.transform.rotation = new Quaternion (0, 0, 0, 0);
				PlayerR.transform.rotation = new Quaternion (0, 180f, 0, 0);
			} else {
				shotDirection = new Vector2 (1f, 0);
				PlayerL.transform.rotation = new Quaternion (0, 180f, 0, 0);
				PlayerR.transform.rotation = new Quaternion (0, 0, 0, 0);
			}
			PlayerL.velocity = new Vector2 (Input.GetAxis ("Horizontal") * speed, PlayerL.velocity.y);
			PlayerR.velocity = new Vector2 (-Input.GetAxis ("Horizontal") * speed, PlayerR.velocity.y);
		}
		if (Mathf.Abs (Input.GetAxis ("Vertical")) > 0) {
			if (Input.GetAxis ("Vertical") > 0) {
				shotDirection = new Vector2 (0, 1f);
			} else {
				shotDirection = new Vector2 (0, -1f);
			}
			PlayerL.velocity = new Vector2 (PlayerL.velocity.x, Input.GetAxis ("Vertical") * speed);
			PlayerR.velocity = new Vector2 (PlayerR.velocity.x, Input.GetAxis ("Vertical") * speed);
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			GameObject objL = (GameObject)Instantiate (shot, PlayerL.position, new Quaternion (0, 0, 0, 0));
			objL.GetComponent<Shot> ().Direction = shotDirection + PlayerL.velocity;
			GameObject objR = (GameObject)Instantiate (shot, PlayerR.position, new Quaternion (0, 0, 0, 0));
			objR.GetComponent<Shot> ().Direction = new Vector2 (-shotDirection.x, shotDirection.y) + PlayerR.velocity;
		}
	}
}
