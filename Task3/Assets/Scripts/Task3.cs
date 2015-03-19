using UnityEngine;
using System.Collections;

public class Task3 : MonoBehaviour
{

	// Use this for initialization
	int dimX = 15;
	int dimY = 25;
	Color[] colors = {Color.white, Color.green, Color.red, Color.yellow, Color.cyan};

	public GameObject circle;

	//TODO: remove static fields
	public static GameObject[,] gameField;  
	public static int score = 0;

	void Start ()
	{
		gameField = new GameObject[dimX, dimY];
		for (int i = 0; i < dimX; i++) {
			GameObject p = new GameObject ("p" + i);
			for (int j = 0; j < dimY; j++) {
				gameField [i, j] = (GameObject)Instantiate (circle, new Vector3 (i, j, 0f), new Quaternion (0, 0, 0, 0));
				gameField [i, j].name = string.Format ("c_{0:00}_{1:00}", i, j);
				gameField [i, j].GetComponent<SpriteRenderer> ().color = colors [Random.Range (0, 5)];
				gameField [i, j].transform.parent = p.transform;
			}
		}
	}
}
