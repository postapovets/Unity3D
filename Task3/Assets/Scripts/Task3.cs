using UnityEngine;
using System.Collections;

public class Task3 : MonoBehaviour
{

	// Use this for initialization
	static int dimX = 15;
	static int dimY = 25;
	Color[] colors = {Color.white, Color.green, Color.red, Color.yellow, Color.cyan};

	public GameObject circle;

	public static GameObject[,] gameField = new GameObject[dimX, dimY];

	void Start ()
	{
		for (int i = 0; i < dimX; i++) {
			for (int j = 0; j < dimY; j++) {
				gameField [i, j] = (GameObject)Instantiate (circle, new Vector3 (i, j, 0f), new Quaternion (0, 0, 0, 0));
				gameField [i, j].name = string.Format ("c_{0:00}_{1:00}", i, j);
				gameField [i, j].GetComponent<SpriteRenderer> ().color = colors [Random.Range (0, 5)];
			}
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public static void SortField ()
	{
		for (int i = 0; i < 15; i++) {
			bool swapped = true;
			while (swapped) {
				swapped = false;
				for (int j = 0; i < 24; j++) {
					if (!gameField [i, j].GetComponent<SpriteRenderer> ().color.Equals (Color.clear) &&
						gameField [i, j + 1].GetComponent<SpriteRenderer> ().color.Equals (Color.clear)) {
						gameField [i, j + 1].GetComponent<SpriteRenderer> ().color = 
							gameField [i, j].GetComponent<SpriteRenderer> ().color;

						gameField [i, j].GetComponent<SpriteRenderer> ().color = Color.clear;
						swapped = true;
					}
				}
			}
		}
	}
}
