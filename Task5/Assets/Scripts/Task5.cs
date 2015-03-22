using UnityEngine;
using System.Collections;

public class Task5 : MonoBehaviour
{
	public Sprite[] Shapes = new Sprite[3];
	public GameObject GObj;
	GameObject obj;
	// Use this for initialization
	void Start ()
	{
		for (int i = 0; i < 10; i++) {
			int s = Random.Range (0, 3);
			obj = (GameObject)Instantiate (GObj, new Vector3 (Random.Range (-3f, 3f), 
			                                       Random.Range (-3f, 3f), 
			                                       Random.Range (-3f, 3f)), new Quaternion (0f, 0f, 0f, 0f));
			obj.GetComponent<SpriteRenderer> ().sprite = Shapes [s];
			obj.transform.parent = transform;
			switch (s) {
			case 0:
				obj.tag = "circle";
				break;
			case 1:
				obj.tag = "cube";
				break;
			case 2:
				obj.tag = "triangle";
				break;
			}
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
