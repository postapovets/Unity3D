using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Task3 : MonoBehaviour
{

	// Use this for initialization
	int dimX = 15;
	int dimY = 25;
	Color[] colors = {Color.white, Color.green, Color.red, Color.yellow, Color.cyan};

	public GameObject circle;

	//TODO: remove static fields
	public GameObject[,] gameField;
	List<GameObject> selectedObj = new List<GameObject> ();
	public int score = 0;
	int currentScore = 0;

	void Start ()
	{
		gameField = new GameObject[dimX, dimY];
		for (int i = 0; i < dimX; i++) {
			GameObject p = new GameObject ("p" + i);
			p.transform.parent = transform.root.transform;
			for (int j = 0; j < dimY; j++) {
				gameField [i, j] = (GameObject)Instantiate (circle, new Vector3 (i, j, 0f), new Quaternion (0, 0, 0, 0));
				gameField [i, j].name = string.Format ("c_{0:00}_{1:00}", i, j);
				gameField [i, j].GetComponent<SpriteRenderer> ().color = colors [Random.Range (0, 5)];
				gameField [i, j].transform.parent = p.transform;
			}
		}
	}

	void Update ()
	{
		if (score > currentScore) {
			currentScore = score;
			transform.root.transform.FindChild ("TextScore").transform.GetComponent<TextMesh> ().text = "Score: " + currentScore;
		}
	}

	void SortField ()
	{
		for (int i = 0; i < dimX; i++) { // sort columns
			int k1 = 0;
			int k2 = dimY - 1;
			GameObject[] tmpObjs = new GameObject[dimY];
			for (int j = 0; j < dimY; j++) {
				tmpObjs [j] = gameField [i, j];
			}
			for (int j = 0; j < dimY; j++) {
				if (tmpObjs [j] == null) {
					gameField [i, k2] = null;
					k2--;
				} else {
					gameField [i, k1] = tmpObjs [j];
					gameField [i, k1].name = string.Format ("c_{0:00}_{1:00}", i, k1);
					k1++;
				}
			}
		}
		// move empty columt to right
		bool swapped = true;
		while (swapped) {
			swapped = false;
			for (int i = 0; i < dimX - 1; i++) {
				if (gameField [i + 1, 0] == null) {
					for (int j = 0; j < dimY; j++) {
						gameField [i + 1, j] = gameField [i, j];
						gameField [i, j] = null;
						if (gameField [i + 1, j] != null)
							gameField [i + 1, j].name = string.Format ("c_{0:00}_{1:00}", i + 1, j);
					}
					swapped = true;
					if (gameField [i + 1, 0] != null)
						gameField [i + 1, 0].transform.parent.transform.position += new Vector3 (1, 0, 0);
				}
			}
		}
		string str = "";
		for (int i = 0; i < dimX; i++) {
			for (int j = 0; j < dimY; j++) {
				if (gameField [i, j] == null)
					str += "0 ";
				else
					str += "1 ";
			}
			str += "\n";
		}
		print (str);
	}

	void SelectBubbles (int i, int j, Color color)
	{
		if (gameField [i, j] != null) {
			if (selectedObj.Contains (gameField [i, j]))
				return;
			if (gameField [i, j].GetComponent<SpriteRenderer> ().color == color) {
				selectedObj.Add (gameField [i, j]);
				if (i > 0)
					SelectBubbles (i - 1, j, color);
				if (j > 0)
					SelectBubbles (i, j - 1, color);
				if (i < dimX - 1)
					SelectBubbles (i + 1, j, color);
				if (j < dimY - 1)
					SelectBubbles (i, j + 1, color);
			}
		}
	}

	public void DestroyBubbles (int i, int j, Color color)
	{
		SelectBubbles (i, j, color);
		if (selectedObj.Count > 0) {
			score += selectedObj.Count; // update score text
			foreach (GameObject item in selectedObj) {
				int itemX = int.Parse (item.name.Substring (2, 2));
				int itemY = int.Parse (item.name.Substring (5, 2));
				Destroy (item);
				gameField [itemX, itemY] = null;
			}
			selectedObj.Clear ();
			SortField ();
		}
	}
}
