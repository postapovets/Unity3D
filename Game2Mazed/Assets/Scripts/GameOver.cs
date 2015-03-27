using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour
{
	
	public Rigidbody2D PlayerL;
	public Rigidbody2D PlayerR;

	public bool MyGameOver {
		get { return (doneLeft && doneRight);}
	}


	bool doneLeft = false;
	bool doneRight = false;

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.name == "PlayerL") {
			doneLeft = true;
		}
		if (other.name == "PlayerR") {
			doneRight = true;
		}
	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.name == "PlayerL") {
			doneLeft = false;
		}
		if (other.name == "PlayerR") {
			doneRight = false;
		}
	}

	void OnEnable ()
	{
		doneLeft = false;
		doneRight = false;
	}
}
