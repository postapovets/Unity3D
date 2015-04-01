using UnityEngine;
using System.Collections;

public class cubeExplose : MonoBehaviour
{

//	Explose myCube;

	void OnMouseDown ()
	{
		transform.root.Find ("/Cubes").GetComponent<Explose> ().ExploseCube ();
	}
}
