using UnityEngine;
using System.Collections;

public static class AddMethods
{

	// Global position
	public static void SetX (this Transform t, float x)
	{
		t.position = new Vector3 (x, t.position.y, t.position.z);
	}

	public static void SetY (this Transform t, float y)
	{
		t.position = new Vector3 (t.position.x, y, t.position.z);
	}

	public static void SetZ (this Transform t, float z)
	{
		t.position = new Vector3 (t.position.x, t.position.y, z);
	}

	// Local position
	public static void SetX (this Transform t, float x, bool isLocal)
	{
		if (isLocal)
			t.localPosition = new Vector3 (x, t.localPosition.y, t.localPosition.z);
	}
	
	public static void SetY (this Transform t, float y, bool isLocal)
	{
		if (isLocal)
			t.localPosition = new Vector3 (t.localPosition.x, y, t.localPosition.z);
	}
	
	public static void SetZ (this Transform t, float z, bool isLocal)
	{
		if (isLocal)
			t.localPosition = new Vector3 (t.localPosition.x, t.localPosition.y, z);
	}
}
