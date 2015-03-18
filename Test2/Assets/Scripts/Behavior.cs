using UnityEngine;
using System.Collections;

public class Behavior : MonoBehaviour
{

	// Use this for initialization
	int i;
	int j;
	void Start ()
	{
		i = int.Parse (name.Substring (6, 1));
		j = int.Parse (name.Substring (8, 1));
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnMouseEnter ()
	{
		Colorize (Color.yellow, 2);
		Colorize (Color.green, 1);
		GetComponent<SpriteRenderer> ().color = Color.red;

	}

	void OnMouseExit ()
	{
		Colorize (Color.white, 2);
	}

	private void Colorize (Color color, int size)
	{
		for (int x = i-size; x <= i+size; x++) {
			for (int y = j - size; y <= j+size; y++) {
				if ((x >= 0 && x < 6) && (y >= 0 && y < 6)) {
					Task2.squares [x, y].GetComponent<SpriteRenderer> ().color = color;
				}
			}
		}
	}
}
