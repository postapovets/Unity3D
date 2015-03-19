using UnityEngine;
using System.Collections;

public class updScore : MonoBehaviour
{
	int currentScore = 0;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Task3.score > currentScore) {
			currentScore = Task3.score;
			GetComponent<TextMesh> ().text = "Score: " + currentScore;
		}
	}
}
