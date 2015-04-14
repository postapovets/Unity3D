using UnityEngine;
using System.Collections;

public class LightMoving : MonoBehaviour
{

	void Start ()
	{
		iTween.MoveTo (gameObject, iTween.Hash ("x", -6, "z", -8, "time", 3, "looptype", iTween.LoopType.pingPong, "easetype", iTween.EaseType.easeInOutQuad));
	}
}
