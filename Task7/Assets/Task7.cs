using UnityEngine;
using System.Collections;

public class Task7 : MonoBehaviour
{
	public GameObject[] PerFabs;
	string str = "";
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.inputString != "") {
			str += Input.inputString;
			if (Input.GetKey (KeyCode.KeypadEnter))
				str = "";
			if (str != "") {
				foreach (GameObject item in PerFabs) {
					if (item.name.Equals (str)) {
						str = "";
						Instantiate (item, 
					            new Vector3 (Random.Range (-5, 5), Random.Range (-5, 5), Random.Range (-5, 5)), 
					            new Quaternion (0, 0, 0, 0));
					}
				}
			}
		}
	}
}
