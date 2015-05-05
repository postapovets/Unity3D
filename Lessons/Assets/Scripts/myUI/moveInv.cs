using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class moveInv : MonoBehaviour
{

	public GameObject cursor;

	public void onClick ()
	{
		if (cursor.GetComponent<Image> ().sprite == null) {
			cursor.GetComponent<Image> ().sprite = GetComponent<Image> ().sprite;
			cursor.GetComponent<Image> ().color = new Color (1f, 1f, 1f, 1f);
			GetComponent<Image> ().sprite = null;
			GetComponent<Image> ().color = new Color (1f, 1f, 1f, 0f);
		} else {
			if (GetComponent<Image> ().sprite == null) {
				GetComponent<Image> ().sprite = cursor.GetComponent<Image> ().sprite;
				GetComponent<Image> ().color = new Color (1f, 1f, 1f, 1f);
				cursor.GetComponent<Image> ().color = new Color (1f, 1f, 1f, 0f);
				cursor.GetComponent<Image> ().sprite = null;
			} else {
				Sprite tmpSprite = cursor.GetComponent<Image> ().sprite;
				cursor.GetComponent<Image> ().sprite = GetComponent<Image> ().sprite;
				GetComponent<Image> ().sprite = tmpSprite;
			}
		}
	}
}
