using UnityEngine;
using System.Collections;

public class BlinkLight : MonoBehaviour
{
	float angleDirection = 1f;
	void Update ()
	{
		transform.Rotate (0f, Time.deltaTime * angleDirection * 200f, 0f);
	}
}
