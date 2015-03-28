using UnityEngine;
using System.Collections;

public class scrPlayer : MonoBehaviour
{
	public TextMesh scoreText;
	public GameObject shot;
	public int speed;
	public bool InverseMoving = false;
	int inverseMoving = 1;
	Quaternion leftMove;
	Quaternion rightMove;
	Rigidbody2D myBody;
	Vector2 shotDirection;

	int score;
	public int Score {
		get { return score;}
		set {
			score = value;
			scoreText.text = score.ToString ();
		}
	}

	void Start ()
	{
		myBody = gameObject.GetComponent<Rigidbody2D> ();
		if (InverseMoving) {
			inverseMoving = -1;
			shotDirection = new Vector2 (1f, 0);
			leftMove = new Quaternion (0, 0, 0, 0);
			rightMove = new Quaternion (0, 180f, 0, 0);
		} else {
			shotDirection = new Vector2 (-1f, 0);
			leftMove = new Quaternion (0, 180f, 0, 0);
			rightMove = new Quaternion (0, 0, 0, 0);
		}
	}

	void FixedUpdate ()
	{
		if (Mathf.Abs (Input.GetAxis ("Vertical")) > 0) {
			myBody.velocity = new Vector2 (myBody.velocity.x, Input.GetAxis ("Vertical") * speed);
			if (Input.GetAxis ("Vertical") > 0) {
				shotDirection = new Vector2 (0, 1f);
			} else {
				shotDirection = new Vector2 (0, -1f);
			}
		}
		if (Mathf.Abs (Input.GetAxis ("Horizontal")) > 0) {
			myBody.velocity = new Vector2 (Input.GetAxis ("Horizontal") * speed * inverseMoving, myBody.velocity.y);
			if (Input.GetAxis ("Horizontal") < 0) {
				myBody.transform.rotation = rightMove;
				shotDirection = new Vector2 (-1f * inverseMoving, 0);
			} else {
				myBody.transform.rotation = leftMove;
				shotDirection = new Vector2 (1f * inverseMoving, 0);
			}
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			GameObject objL = (GameObject)Instantiate (shot, myBody.position, new Quaternion (0, 0, 0, 0));
			objL.GetComponent<Shot> ().Owner = myBody;
			objL.GetComponent<Shot> ().Direction = shotDirection + myBody.velocity;
		}
	}
}
