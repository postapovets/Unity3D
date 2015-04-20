using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class singlTxt : MonoBehaviour
{

	private int score;

	void Start ()
	{
		score = Singletone1.singletone.GetCoins ();
	}

	void Update ()
	{
		if (score != Singletone1.singletone.GetCoins ()) {
			score = Singletone1.singletone.GetCoins ();

			transform.GetComponent<Text> ().text = "Score: " + score;
		}
	}
}
