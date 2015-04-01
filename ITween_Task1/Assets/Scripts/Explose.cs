using UnityEngine;
using System.Collections;

public class Explose : MonoBehaviour
{
	public GameObject perfabCube;

	GameObject[,,] myCube = new GameObject[3, 3, 3];

	// Use this for initialization
	void Start ()
	{
		CreateCube ();
	}

	void CreateCube ()
	{
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				for (int k = 0; k < 3; k++) {
					myCube [i, j, k] = (GameObject)Instantiate (perfabCube, new Vector3 (i, j, k), new Quaternion (0, 0, 0, 0));
				}
			}
		}
	}

	public void ExploseCube ()
	{
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				for (int k = 0; k < 3; k++) {
					iTween.MoveAdd (myCube [i, j, k], iTween.Hash ("y", Random.Range (0.1f, 5f),
					                                            "x", Random.Range (-7f, 7f)));
				}
			}
		}
	}
}
