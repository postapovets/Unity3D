using UnityEngine;
using System.Collections;

public class main : MonoBehaviour
{

	// Use this for initialization
	public GameObject Obj;
	GameObject obj;
	void Start ()
	{
		obj = (GameObject)Instantiate (Obj, new Vector2 (Random.Range (-3, 3), Random.Range (-3, 3)), new Quaternion (0, 0, 0, 0));
		obj.GetComponent<SpriteRenderer> ().color = Color.red;

		obj = (GameObject)Instantiate (Obj, new Vector2 (Random.Range (-3, 3), Random.Range (-3, 3)), new Quaternion (0, 0, 0, 0));
		obj.GetComponent<SpriteRenderer> ().color = Color.green;

		obj = (GameObject)Instantiate (Obj, new Vector2 (Random.Range (-3, 3), Random.Range (-3, 3)), new Quaternion (0, 0, 0, 0));
		obj.GetComponent<SpriteRenderer> ().color = Color.cyan;

		obj = (GameObject)Instantiate (Obj, new Vector2 (Random.Range (-3, 3), Random.Range (-3, 3)), new Quaternion (0, 0, 0, 0));
		obj.GetComponent<SpriteRenderer> ().color = Color.magenta;

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButton (0)) {
			transform.root.Find ("/Player").transform.position += new Vector3 (Input.GetAxis ("Mouse X") / 8, Input.GetAxis ("Mouse Y") / 8, 0);
//			transform.root.Find ("/Player").transform.position = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0);
		}
	}
}
