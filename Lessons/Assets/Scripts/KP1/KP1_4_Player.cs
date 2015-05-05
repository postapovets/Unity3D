using UnityEngine;
using System.Collections;
[ExecuteInEditMode]

public class KP1_4_Player : MonoBehaviour
{
	public float speed;

	private Rigidbody myBody;
	private int score = 0;
	private bool isWin = false;

	void Start ()
	{
		myBody = GetComponent<Rigidbody> ();
	}
	
	void OnGUI ()
	{
		if (isWin)

			GUI.TextArea (new Rect (10, 20, Screen.width - 20, Screen.height - 30), "You Win!" + "\n" + 
				"You score is " + score);

	}

	void FixedUpdate ()
	{
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");
		myBody.AddForce (new Vector3 (h * speed, 0, 0));
		myBody.AddForce (new Vector3 (0, 0, v * speed));
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "BadFire") {
			Application.LoadLevel (0);
		}
		if (other.tag == "GoodFire") {
			Destroy (other.gameObject);
			score++;
			if (GameObject.FindGameObjectsWithTag ("GoodFire").Length == 1) {
				isWin = true;
			}
		}
	}
}
