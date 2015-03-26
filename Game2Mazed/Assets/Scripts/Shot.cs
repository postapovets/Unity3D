﻿using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour
{
	public float Speed;
	public Vector2 Direction;
	Vector3 startPoint;
	
	// Use this for initialization
	void Start ()
	{
		startPoint = transform.position;
		gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (Direction.x * Speed, Direction.y * Speed);
	}

	void FixedUpdate ()
	{
		if (Vector3.Distance (transform.position, startPoint) > 1) {
			Destroy (gameObject);
		}
	}
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Furniture") {
			Destroy (other.gameObject);
		}
		if (other.tag != "Player")
			Destroy (gameObject);
	}
}
