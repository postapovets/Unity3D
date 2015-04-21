using UnityEngine;
using System.Collections;

public static class addMethInput
{

	public static bool TwoKeysDown (this Input inp, string key1, string key2)
	{
		return (Input.GetKeyDown (key1) && Input.GetKeyDown (key2));
	}

	public static bool TwoKeys (this Input inp, string key1, string key2)
	{
		return (Input.GetKey (key1) && Input.GetKey (key2));
	}

	public static bool TwoKeysUp (this Input inp, string key1, string key2)
	{
		return (Input.GetKeyUp (key1) && Input.GetKeyUp (key2));
	}

	public static bool TwoKeysDown (this Input inp, KeyCode key1, KeyCode key2)
	{
		return (Input.GetKeyDown (key1) && Input.GetKeyDown (key2));
	}
	
	public static bool TwoKeys (this Input inp, KeyCode key1, KeyCode key2)
	{
		return (Input.GetKey (key1) && Input.GetKey (key2));
	}
	
	public static bool TwoKeysUp (this Input inp, KeyCode key1, KeyCode key2)
	{
		return (Input.GetKeyUp (key1) && Input.GetKeyUp (key2));
	}
}
