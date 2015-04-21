using UnityEngine;
using System.Collections;

public static class addMethV3
{
	public static Vector3 RandomV3 (this Vector3 v, Vector3 v1, Vector3 v2)
	{
		return new Vector3 (Random.Range (v1.x, v2.x), Random.Range (v1.y, v2.y), Random.Range (v1.z, v2.z));
	}

	public static Vector3 RandomV3 (this Vector3 v, Vector3 v1, float x, float y, float z)
	{
		return new Vector3 (Random.Range (v1.x, x), Random.Range (v1.y, y), Random.Range (v1.z, z));
	}
}
