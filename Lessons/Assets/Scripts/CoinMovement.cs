using UnityEngine;
using System.Collections;

public class CoinMovement : MonoBehaviour
{

	void Start ()
	{
		if (tag == "Coin") {
			iTween.RotateAdd (gameObject, iTween.Hash ("y", 360, "time", 2, "looptype", iTween.LoopType.loop, "easetype", iTween.EaseType.linear));
		} else if (tag == "Poison") {
			iTween.RotateAdd (gameObject, iTween.Hash ("y", -360, "time", 2, "looptype", iTween.LoopType.loop, "easetype", iTween.EaseType.linear));
		}
	}
}
