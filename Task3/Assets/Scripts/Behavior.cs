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

	void OnMouseDown ()
	{
		bool isHavePair = false;

		if (this.MarkLeft (x, y))
			isHavePair = true;

		if (this.MarkRight (x, y))
			isHavePair = true;
			
		if (this.MarkDown (x, y))
			isHavePair = true;

		if (this.MarkUp (x, y))
			isHavePair = true;

		if (isHavePair) {
			gameObject.GetComponent<SpriteRenderer> ().color = Color.clear;
			SortField ();
		}
	}

	void SortField ()
	{
		for (int i = 0; i < 15; i++) {
			//sort col
			int k1 = 0;
			int k2 = 24;
			Color[] tmpColors = new Color[25];
			for (int j = 0; j < 25; j++) {
				if (Task3.gameField [i, j].GetComponent<SpriteRenderer> ().color.Equals (Color.clear)) {
					tmpColors [k2] = Color.clear;
					k2--;
				} else {
					tmpColors [k1] = Task3.gameField [i, j].GetComponent<SpriteRenderer> ().color;
					k1++;
				}
			}
			for (int j = 0; j < 25; j++) {
				Task3.gameField [i, j].GetComponent<SpriteRenderer> ().color = tmpColors [j];
			}
		}
	}

	private bool MarkLeft (int i, int j)
	{
		if (i - 1 >= 0 && gameObject.GetComponent<SpriteRenderer> ().color == Task3.gameField [i - 1, j].GetComponent<SpriteRenderer> ().color) {
			this.MarkLeft (i - 1, j);
			Task3.gameField [i - 1, j].GetComponent<SpriteRenderer> ().color = Color.clear;
			return true;
		} else {
			return false;
		}
	}
	private bool MarkRight (int i, int j)
	{
		if (i + 1 < 15 && gameObject.GetComponent<SpriteRenderer> ().color == Task3.gameField [i + 1, j].GetComponent<SpriteRenderer> ().color) {
			this.MarkRight (i + 1, j);
			Task3.gameField [i + 1, j].GetComponent<SpriteRenderer> ().color = Color.clear;
			return true;
		} else {
			return false;
		}
	}
	private bool MarkDown (int i, int j)
	{
		if (j - 1 >= 0 && gameObject.GetComponent<SpriteRenderer> ().color == Task3.gameField [i, j - 1].GetComponent<SpriteRenderer> ().color) {
			this.MarkDown (i, j - 1);
			Task3.gameField [i, j - 1].GetComponent<SpriteRenderer> ().color = Color.clear;
			return true;
		} else {
			return false;
		}
	}
	private bool MarkUp (int i, int j)
	{
		if (j + 1 < 25 && gameObject.GetComponent<SpriteRenderer> ().color == Task3.gameField [i, j + 1].GetComponent<SpriteRenderer> ().color) {
			this.MarkUp (i, j + 1);
			Task3.gameField [i, j + 1].GetComponent<SpriteRenderer> ().color = Color.clear;
			return true;
		} else {
			return false;
		}
	}
}
