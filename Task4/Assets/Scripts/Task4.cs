using UnityEngine;
using System.Collections;


public class Task4 : MonoBehaviour
{


	public GameObject Cube;
	public GameObject Sphere;
	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
		Cube.transform.LookAt (Sphere.transform.position);
		Cube.transform.position = Vector3.MoveTowards (Cube.transform.position, Sphere.transform.position, 0.05f);
	}
}
