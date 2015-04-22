using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public speed;

	private Transform player;

	bool isGrounded = true;

	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	void FixedUpdate () {
		float v = Input.GetAxis("Vertical");

		if (isGrounded) {

		}

		//update animator

	}
}
