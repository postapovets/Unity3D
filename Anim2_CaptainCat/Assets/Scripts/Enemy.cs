using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
	
	public Transform groundSensor;
	public Transform groundForwardSensor;
	public Transform forwardSensor;
	public LayerMask groundLayer;
	public GameObject prefabShot;

	Transform player;
	bool onGround = false;
	bool onForwardGround = true;
	bool needJump = false;
	Rigidbody2D myBody;
	Animator myAnim;
	bool directionR = true;
	float acceleration = 1f;
	float timer = 0;
	
	
	// Use this for initialization
	void Start ()
	{
		myBody = GetComponent<Rigidbody2D> ();
		myAnim = GetComponent<Animator> ();
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (onGround && needJump) {
			onGround = false;
			needJump = false;
			myBody.velocity = new Vector2 (myBody.velocity.x, 5);
		}
		timer += Time.deltaTime;
		if (myBody.transform.position.y < -3) {
			myBody.position = new Vector2 (2, 0);
		}
	}

	void Fire ()
	{
		if (timer > 1) {
			GameObject obj = (GameObject)Instantiate (prefabShot, transform.position, Quaternion.identity);
			obj.GetComponent<Rigidbody2D> ().velocity = new Vector2 (acceleration * 5, 0);
			timer = 0;
		}

	}
	
	void FixedUpdate ()
	{
		onGround = Physics2D.OverlapCircle (groundSensor.position, 0.2f, groundLayer);
		needJump = Physics2D.OverlapCircle (forwardSensor.position, 0.2f, groundLayer);
		onForwardGround = Physics2D.OverlapCircle (groundForwardSensor.position, 0.2f, groundLayer);
		myAnim.SetBool ("OnGround", onGround);
		myAnim.SetFloat ("SpeedY", myBody.velocity.y);
		if (!onGround)
			return;
		if (!onForwardGround) { //turn
			acceleration *= -1;
		}
		myAnim.SetFloat ("SpeedX", Mathf.Abs (acceleration));
		myBody.velocity = new Vector2 (acceleration * 2, myBody.velocity.y);
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
		// Fire
		if (Mathf.Abs (transform.position.y - player.position.y) < 0.1f) { // on same level
			if (transform.position.x - player.position.x > 0) {
				acceleration = -1f;
				Fire ();
			} else {
				acceleration = 1f;
				Fire ();
			}
		}
	}
}
