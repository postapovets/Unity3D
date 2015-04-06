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

	public int health = 3;
	public Text txtHealth;
	public int score = 0;
	public Text txtScore;

	// Use this for initialization
	void Start ()
	{
		myBody = GetComponent<Rigidbody2D> ();
		myAnim = GetComponent<Animator> ();
		txtHealth.text = "Health: " + health;
		txtScore.text = "Score: " + score;
		
	}
	
	// Update is called once per frame
	void Update ()
	{
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
		health--;
		if (health < 1) {
			RestartLevel ();
		}
		txtHealth.text = "Health: " + health;
	}
	public void CollectCoin ()
	{
		score++;
		txtScore.text = "Score: " + score;
	}


	void RestartLevel ()
	{
		myBody.position = new Vector2 (5, 1);
		health = 3;
		txtHealth.text = "Health: " + health;
	}
}
