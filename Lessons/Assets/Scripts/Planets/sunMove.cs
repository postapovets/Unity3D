using UnityEngine;
using System.Collections;

public class sunMove : MonoBehaviour
{

	void Update ()
	{
		transform.SetX (transform.position.x + 0.0005f);
	}
}
