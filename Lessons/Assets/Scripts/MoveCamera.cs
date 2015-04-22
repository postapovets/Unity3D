using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour
{

	public float Smooth; // speed camera moving

	public Transform Player;
	private Vector3 relPlayerPosition;

	private Vector3 camPosition;
	private Vector3 newCamPosition;
	private Vector3 m_CamForward;             // The current forward direction of the camera
	


	void Start ()
	{
		Player = GameObject.FindGameObjectWithTag ("Player").transform;

		// Setting camera position in scene
		camPosition = transform.position - Player.position;
	}

	void FixedUpdate ()
	{

		print (Input.mousePosition);

		// smooth move cam to new position
		newCamPosition = Player.position + camPosition;
		transform.position = Vector3.Lerp (transform.position, newCamPosition, Time.deltaTime * Smooth);
		/*
		// rotate cam
		m_CamForward = Vector3.Scale(Player.forward, new Vector3(1, 0, 1)).normalized;

		relPlayerPosition = Player.position - transform.position;
		Quaternion camRotation = Quaternion.LookRotation (relPlayerPosition, Vector3.up);
		transform.rotation = Quaternion.Lerp (transform.rotation, camRotation, Smooth * Time.deltaTime);
		*/
	}
}
