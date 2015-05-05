using UnityEngine;
using System.Collections;

public class moveCursor : MonoBehaviour
{


	void Update ()
	{
		transform.position = new Vector3 (Input.mousePosition.x - 35, Input.mousePosition.y + 20, 0f);
	}
}
