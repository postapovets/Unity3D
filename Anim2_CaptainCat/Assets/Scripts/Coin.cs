using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		iTween.RotateAdd (gameObject, iTween.Hash ("y", 360, "time", 2, "looptype", iTween.LoopType.loop, "easetype", iTween.EaseType.linear));
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player") {
			other.GetComponent<Cat> ().CollectCoin ();
			Vector3[] path = new Vector3[] {
				new Vector3 (transform.position.x, transform.position.y + 1, transform.position.z - 1),
				new Vector3 (transform.position.x, transform.position.y, transform.position.z - 1),
				new Vector3 (transform.position.x, -3, transform.position.z + 1)};
			iTween.MoveTo (gameObject, iTween.Hash ("path", path, "easetype", iTween.EaseType.linear, "time", 2, "oncomplete", "KillSelf"));
			GetComponent<Collider2D> ().enabled = false;
		}
	}

	void KillSelf ()
	{
		Destroy (gameObject);
	}
}
