using UnityEngine;
using System.Collections;

public class main : MonoBehaviour
{

	// Use this for initialization
	public GameObject Obj;
	GameObject[] objects = new GameObject[10];
	Transform player;
	void Start ()
	{
		player = transform.root.Find ("/Player");
		for (int i = 0; i < objects.Length; i++) {
			objects [i] = (GameObject)Instantiate (Obj, new Vector2 (Random.Range (-3, 3), Random.Range (-3, 3)), new Quaternion (0, 0, 0, 0));
			objects [i].GetComponent<SpriteRenderer> ().color = new Color (Random.Range (0, 1f), Random.Range (0, 1f), Random.Range (0, 1f));
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButton (0)) { // Move Player object
			player.position = (Vector2)Camera.main.ScreenToWorldPoint (Input.mousePosition);
		}
		Color tmpColor = objects [0].transform.GetComponent<SpriteRenderer> ().color;
		float dist = Vector2.Distance (player.position, objects [0].transform.position);
		for (int i = 1; i < objects.Length; i++) {
			if (Vector2.Distance (player.position, objects [i].transform.position) < dist) {
				dist = Vector2.Distance (player.position, objects [i].transform.position);
				tmpColor = objects [i].transform.GetComponent<SpriteRenderer> ().color;
			}
		}
		player.GetComponent<SpriteRenderer> ().color = Color.Lerp (player.GetComponent<SpriteRenderer> ().color, tmpColor, 0.05f);
	}
}
