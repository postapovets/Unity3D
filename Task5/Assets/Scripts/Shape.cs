using UnityEngine;
using System.Collections;

public class Shape : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnMouseDown ()
	{
		switch (transform.tag) {
		case "circle":
			transform.parent = GameObject.Find ("/Circles").transform;
			transform.name = "circle_" + GameObject.Find ("/Circles").transform.childCount;
			GetComponent<SpriteRenderer> ().color = Color.green;
			break;
		case "cube":
			transform.parent = GameObject.Find ("/Cubes").transform;
			transform.name = "cube_" + GameObject.Find ("/Cubes").transform.childCount;
			GetComponent<SpriteRenderer> ().color = Color.green;
			break;
		case "triangle":
			transform.parent = GameObject.Find ("/Triangles").transform;
			transform.name = "triangle_" + GameObject.Find ("/Triangles").transform.childCount;
			GetComponent<SpriteRenderer> ().color = Color.green;
			break;
		}
		if (GameObject.Find ("/Unsorted").transform.childCount == 0) {
			foreach (Transform child in GameObject.Find ("/Circles").transform) {
				if (child.tag != "circle") 
					child.GetComponent<SpriteRenderer> ().color = Color.red;
			}
			foreach (Transform child in GameObject.Find ("/Cubes").transform) {
				if (child.tag != "cube") 
					child.GetComponent<SpriteRenderer> ().color = Color.red;
			}
			foreach (Transform child in GameObject.Find ("/Triangles").transform) {
				if (child.tag != "triangle") 
					child.GetComponent<SpriteRenderer> ().color = Color.red;
			}
		}
	}
}
