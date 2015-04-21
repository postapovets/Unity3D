using UnityEngine;
using System.Collections;

public class TwoKeysInput : MonoBehaviour
{

	Input inp = new Input ();
	void Update ()
	{
		if (inp.TwoKeysDown ("a", "b"))
			print ("a and b pressed");
		if (inp.TwoKeys ("a", "b"))
			print ("a and b pressing");
		if (inp.TwoKeysUp ("a", "b"))
			print ("a and b released");


		if (inp.TwoKeysDown (KeyCode.A, KeyCode.B))
			print ("a and b pressed");
		if (inp.TwoKeys (KeyCode.A, KeyCode.B))
			print ("a and b pressing");
		if (inp.TwoKeysUp (KeyCode.A, KeyCode.B))
			print ("a and b released");
	}
}
