using UnityEngine;
using System.Collections;

public class scrCamera : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit rcHit;
			if (Physics.Raycast (ray, out rcHit, 20f)) {

				rcHit.collider.GetComponent<Player> ().destColor = new Color (Random.Range (0, 1f), Random.Range (0, 1f), Random.Range (0, 1f));
			}
		}
	}
}
