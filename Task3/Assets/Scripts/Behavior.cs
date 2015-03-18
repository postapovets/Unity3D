using UnityEngine;
using System.Collections;

public class Behavior : MonoBehaviour
{
	int x;
	int y;

	// Use this for initialization
	void Start ()
	{
		x = int.Parse (name.Substring (2, 2));
		y = int.Parse (name.Substring (5, 2));
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnMouseDown ()
	{
		bool isHavePair = false;

		if (x - 1 >= 0 && gameObject.GetComponent<SpriteRenderer> ().color == Task3.gameField [x - 1, y].GetComponent<SpriteRenderer> ().color) {
			isHavePair = true;
			Task3.gameField [x - 1, y].GetComponent<SpriteRenderer> ().color = Color.clear;
		}

		if (x + 1 < 15 && gameObject.GetComponent<SpriteRenderer> ().color == Task3.gameField [x + 1, y].GetComponent<SpriteRenderer> ().color) {
			isHavePair = true;
			Task3.gameField [x + 1, y].GetComponent<SpriteRenderer> ().color = Color.clear;
			
		}

		if (y - 1 >= 0 && gameObject.GetComponent<SpriteRenderer> ().color == Task3.gameField [x, y - 1].GetComponent<SpriteRenderer> ().color) {
			isHavePair = true;
			Task3.gameField [x, y - 1].GetComponent<SpriteRenderer> ().color = Color.clear;
			
		}
		
		if (y + 1 < 25 && gameObject.GetComponent<SpriteRenderer> ().color == Task3.gameField [x, y + 1].GetComponent<SpriteRenderer> ().color) {
			isHavePair = true;
			Task3.gameField [x, y + 1].GetComponent<SpriteRenderer> ().color = Color.clear;
			
		}

		if (isHavePair) {
			gameObject.GetComponent<SpriteRenderer> ().enabled = false;
			Task3.SortField ();
		}
	}
}
