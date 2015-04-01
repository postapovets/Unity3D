using UnityEngine;
using System.Collections;

public class JumpSphere : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		iTween.MoveAdd (gameObject, iTween.Hash ("x", 1, "y", 1, "delay", 1, "time", 1, "EaseType", iTween.EaseType.easeOutQuad));
		iTween.ColorTo (gameObject, iTween.Hash ("r", Random.Range (0, 1f), "g", Random.Range (0, 1f), "b", Random.Range (0, 1f), "delay", 1, "time", 2, "EaseType", iTween.EaseType.linear));
		iTween.MoveAdd (gameObject, iTween.Hash ("x", 1, "y", -1, "delay", 2, "time", 1, "EaseType", iTween.EaseType.easeInQuad));
		iTween.MoveAdd (gameObject, iTween.Hash ("x", 1, "y", 1, "delay", 3, "time", 1, "EaseType", iTween.EaseType.easeOutQuad));
		iTween.ColorTo (gameObject, iTween.Hash ("r", Random.Range (0, 1f), "g", Random.Range (0, 1f), "b", Random.Range (0, 1f), "delay", 3, "time", 2, "EaseType", iTween.EaseType.linear));
		iTween.MoveAdd (gameObject, iTween.Hash ("x", 1, "y", -1, "delay", 4, "time", 1, "EaseType", iTween.EaseType.easeInQuad));
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
