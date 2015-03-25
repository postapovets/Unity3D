using UnityEngine;
using System.Collections;

public class scrCamera : MonoBehaviour
{

	// Use this for initialization
	public GameObject cubePerFab;
	public float k = 1.2f;
	GameObject obj;
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButton (1))
			Camera.main.transform.position += new Vector3 (Input.GetAxis ("Mouse X"), Input.GetAxis ("Mouse Y"), 0);

		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, 100f)) {
				Vector3 objPosition = hit.point + new Vector3 (hit.normal.x * k, hit.normal.y * k, hit.normal.z * k);
				obj = (GameObject)Instantiate (cubePerFab, objPosition, new Quaternion (0, 0, 0, 0));
			}
		}
	}
}
