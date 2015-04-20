using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class singlObj : MonoBehaviour
{

	float timer = 0;
	int score = 0;

	void Update ()
	{
		timer += Time.deltaTime;
		if (timer > 1) {
			score = Random.Range (1, 5);
			Singletone1.singletone.AddCoin (score);
			transform.GetComponent<GUIText> ().text = score.ToString ();
			timer = 0;
		}
	}
}
