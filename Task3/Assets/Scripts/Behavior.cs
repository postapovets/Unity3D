using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Behavior : MonoBehaviour
{
	int x;
	int y;
	Color color;
	List<GameObject> selectedObj = new List<GameObject> ();

	// Use this for initialization
	void Start ()
	{
		color = gameObject.GetComponent<SpriteRenderer> ().color;
	}

	void OnMouseDown ()
	{
		x = int.Parse (name.Substring (2, 2));
		y = int.Parse (name.Substring (5, 2));

		SelectBubbles (x, y);
		if (selectedObj.Count > 1) {
			Task3.score += selectedObj.Count; // TODO: update score text
			foreach (var item in selectedObj) {
				int itemX = int.Parse (item.name.Substring (2, 2));
				int itemY = int.Parse (item.name.Substring (5, 2));
				Destroy (Task3.gameField [itemX, itemY]);
				Task3.gameField [itemX, itemY] = null;
			}
			SortField ();
		}
	}

	void SelectBubbles (int i, int j)
	{
		if (Task3.gameField [i, j] != null) {
			if (selectedObj.Contains (Task3.gameField [i, j]))
				return;
			if (Task3.gameField [i, j].GetComponent<SpriteRenderer> ().color == color) {
				selectedObj.Add (Task3.gameField [i, j]);
				if (i > 0)
					SelectBubbles (i - 1, j);
				if (j > 0)
					SelectBubbles (i, j - 1);
				if (i < 14)
					SelectBubbles (i + 1, j);
				if (j < 24)
					SelectBubbles (i, j + 1);
			}
		}
	}

	void SortField ()
	{
		for (int i = 0; i < 15; i++) { // sort columns
			int k1 = 0;
			int k2 = 24;
			GameObject[] tmpObjs = new GameObject[25];
			for (int j = 0; j < 25; j++) {
				tmpObjs [j] = Task3.gameField [i, j];
			}
			for (int j = 0; j < 25; j++) {
				if (tmpObjs [j] == null) {
					Task3.gameField [i, k2] = null;
					k2--;
				} else {
					Task3.gameField [i, k1] = tmpObjs [j];
					Task3.gameField [i, k1].name = string.Format ("c_{0:00}_{1:00}", i, k1);
					k1++;
				}
			}
		}
		// TODO: move empty columt
/*		for (int i = 0; i < 15; i++) {
			if (Task3.gameField [i + 1, 0] == null) {
				for (int j = 0; j < 25; j++) {
					Task3.gameField [i + 1, j] = Task3.gameField [i, j];
					Task3.gameField [i + 1, j].name = string.Format ("c_{0:00}_{1:00}", i + 1, j);
				}
			}
			// TODO: move GameObject p with childs to right (x+1)
		}*/
	}
}
