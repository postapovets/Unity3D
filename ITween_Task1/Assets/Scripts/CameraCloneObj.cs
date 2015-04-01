using UnityEngine;
using System.Collections;

public class CameraCloneObj : MonoBehaviour
{

	public GameObject Sphere;

	GameObject obj1;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, 100f)) {
				for (int i = Random.Range(0,3); i < 5; i++) {
					obj1 = (GameObject)Instantiate (Sphere, hit.collider.transform.position, new Quaternion (0, 0, 0, 0));
					obj1.transform.parent = hit.collider.transform;
				}
			}
		
		}
	}
}
