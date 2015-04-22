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

	private Vector3 cameraOffset;
	

	// Use this for initialization
	void Start ()
	{
		myBody = GetComponent<Rigidbody2D> ();
		myAnim = GetComponent<Animator> ();
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
		CatScore.catObj.Health--;
		if (CatScore.catObj.Health < 1) {
			RestartLevel ();
		}
	}
	public void CollectCoin ()
	{
		CatScore.catObj.Score++;
	}


	void RestartLevel ()
	{
		CatScore.catObj.Health = 3;
		Application.LoadLevel (0);
	}

	void OnTriggerStay2D (Collider2D other)
	{
		
		if (other.tag == "Door") {
			if (Input.GetKeyDown (KeyCode.Return)) {
				CatScore.catObj.LevelNo = other.GetComponent<Door> ().toLevelNum;
				Application.LoadLevel (CatScore.catObj.LevelNo);
			}
		}
	}
}
