using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Cat : MonoBehaviour
{

	public Transform groundSensor;
	public LayerMask groundLayer;

	bool onGround = false;
	Rigidbody2D myBody;
	Animator myAnim;
	bool directionR = true;


	public Text txtHealth;
	public Text txtScore;

	private Vector3 cameraOffset;
	

	// Use this for initialization
	void Start ()
	{
		myBody = GetComponent<Rigidbody2D> ();
		myAnim = GetComponent<Animator> ();
		txtHealth.text = "Health: " + GameController.Health;
		txtScore.text = "Score: " + GameController.Score;
		cameraOffset = Camera.main.transform.position - transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		Camera.main.transform.position = transform.position + cameraOffset;
		if (onGround && Input.GetKeyDown (KeyCode.Space)) {
			onGround = false;
			myBody.velocity = new Vector2 (myBody.velocity.x, 9);
		}
		if (myBody.transform.position.y < -3) {
			RestartLevel ();
		}
	}

	void FixedUpdate ()
	{
		onGround = Physics2D.OverlapCircle (groundSensor.position, 0.3f, groundLayer);
		myAnim.SetBool ("OnGround", onGround);
		myAnim.SetFloat ("SpeedY", myBody.velocity.y);
		float acceleration = Input.GetAxis ("Horizontal");
		myAnim.SetFloat ("SpeedX", Mathf.Abs (acceleration));
		myBody.velocity = new Vector2 (acceleration * 7, myBody.velocity.y);
		if (directionR && acceleration < 0) {
			Vector3 tmpScale = myBody.transform.localScale;
			tmpScale.x *= -1;
			myBody.transform.localScale = tmpScale;
			directionR = !directionR;
		} else if (!directionR && acceleration > 0) {
			Vector3 tmpScale = myBody.transform.localScale;
			tmpScale.x *= -1;
			myBody.transform.localScale = tmpScale;
			directionR = !directionR;
		}
	}

	public void Demage ()
	{
		GameController.Health--;
		if (GameController.Health < 1) {
			RestartLevel ();
		}
		txtHealth.text = "Health: " + GameController.Health;
	}
	public void CollectCoin ()
	{
		GameController.Score++;
		txtScore.text = "Score: " + GameController.Score;
	}


	void RestartLevel ()
	{
		GameController.Health = 3;
		Application.LoadLevel (0);
	}

	void OnTriggerStay2D (Collider2D other)
	{
		
		if (other.tag == "Door") {
			if (Input.GetKeyDown (KeyCode.Return))
				Application.LoadLevel (other.GetComponent<Door> ().toLevelNum);
		}
	}
}
