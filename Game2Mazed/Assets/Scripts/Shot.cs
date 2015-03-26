using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour
{
	private float shotTime;
	public float Speed;
	public Vector2 Direction;

	// Use this for initialization
	void Start ()
	{
		shotTime = Time.time;
		gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (1f * Speed, 0);

	}

	void FixedUpdate ()
	{
		if (Time.time > (shotTime + 0.5f))
			Destroy (gameObject);
	}

}
