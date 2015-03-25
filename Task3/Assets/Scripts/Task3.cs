using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Task3 : MonoBehaviour
{

	// Use this for initialization
	int dimX = 15;
	int dimY = 25;
	public Color[] colors = {Color.white, Color.green, Color.red, Color.yellow, Color.cyan};

	public GameObject circle;
	public int BubblesToKill = 2;
	
	public GameObject[,] gameField;
	List<GameObject> selectedObj = new List<GameObject> ();
	int score = 0;
	int currentScore = 0;

	void Start ()
	{
		gameField = new GameObject[dimX, dimY];
		GameObject p = new GameObject ();

		for (int i = 0; i < dimX; i++) {
			p = new GameObject ("p" + i);
			p.transform.position = new Vector3 (i, 0, 0);
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
		for (int i = dimX-1; i > 0; i--) {
			if (gameField [i, 0] != null) {
				if (gameField [i - 1, 0] != null) {
					Vector3 a = gameField [i - 1, 0].transform.parent.transform.position;
					Vector3 b = gameField [i, 0].transform.parent.transform.position;
					b -= new Vector3 (1, 0, 0);
					gameField [i - 1, 0].transform.parent.transform.position = Vector3.MoveTowards (a, b, 0.03f);
				}
			}
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
				if (gameField [i + 1, 0] == null && gameField [i, 0] != null) {
					for (int j = 0; j < dimY; j++) {
						gameField [i + 1, j] = gameField [i, j];
						gameField [i, j] = null;
						if (gameField [i + 1, j] != null)
							gameField [i + 1, j].name = string.Format ("c_{0:00}_{1:00}", i + 1, j);
					}
					swapped = true;
					//  if (gameField [i + 1, 0] != null) {
					//gameField [i + 1, 0].transform.parent.transform.position += new Vector3 (1, 0, 0);
					
				}
			}
		}
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

	public void DestroyBubbles (GameObject obj)
	{
		SelectBubbles (int.Parse (obj.name.Substring (2, 2)), int.Parse (obj.name.Substring (5, 2)), obj.GetComponent<SpriteRenderer> ().color);
		if (selectedObj.Count >= BubblesToKill) {
			score += selectedObj.Count; // update score text
			foreach (GameObject item in selectedObj) {
				int itemX = int.Parse (item.name.Substring (2, 2));
				int itemY = int.Parse (item.name.Substring (5, 2));
				item.GetComponent<Light> ().enabled = true;
				Destroy (item, 0.2f);
				gameField [itemX, itemY] = null;
			}
			SortField ();
		}
		selectedObj.Clear ();
	}
}
