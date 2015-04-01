using UnityEngine;
using System.Collections;

public class CloneSphere : MonoBehaviour
{

	public GameObject Sphere;

	// Use this for initialization
	void Start ()
	{

		iTween.RotateAdd (gameObject, iTween.Hash ("x", (Random.Range (0, 2)) * 360,
		                                           "y", (Random.Range (0, 2)) * 360,
		                                           "z", (Random.Range (0, 2)) * 360, 
		                                           "time", 2, 
		                                           "looptype", iTween.LoopType.loop, 
		                                           "easetype", iTween.EaseType.linear));
		iTween.MoveAdd (gameObject, iTween.Hash ("x", Random.Range (-1, 2), "y", Random.Range (-1, 2), "z", Random.Range (-1, 2)));
		iTween.ScaleTo (gameObject, iTween.Hash ("x", 0.5f, "y", 0.5f, "z", 0.5f, "time", 2, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.pingPong));
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

}
