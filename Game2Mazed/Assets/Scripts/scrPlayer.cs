using UnityEngine;
using System.Collections;

public class scrPlayer : MonoBehaviour
{
	public TextMesh scoreText;
	int score;
	public int Score {
		get { return score;}
		set {
			score = value;
			scoreText.text = score.ToString ();
		}
	}
}
