using UnityEngine;
using System.Collections;


public class Behavior : MonoBehaviour
{
	Task3 mainView;

	// Use this for initialization
	void Start ()
	{
		mainView = transform.root.GetComponent<Task3> ();
	}

	void OnMouseDown ()
	{
		mainView.DestroyBubbles (int.Parse (name.Substring (2, 2)),
		                         int.Parse (name.Substring (5, 2)),
		                         gameObject.GetComponent<SpriteRenderer> ().color);
	}
}
