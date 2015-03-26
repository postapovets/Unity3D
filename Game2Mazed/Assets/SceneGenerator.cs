using UnityEngine;
using System.Collections;

public class SceneGenerator : MonoBehaviour
{
	public GameObject perfabWall;
	public GameObject perfabSecret;
	public GameObject perfabExit;
	public GameObject perfabPlayerL;
	public GameObject perfabPlayerR;
	GameObject obj;
	public int numLevel = 1;
	/*
	 * 0 - space
	 * 1 - wall
	 * 2 - secret/bonus
	 * 3 - portal/exit
	 * 4 - left player
	 * 5 - right player
	 */
	int[,,] level = new int[2, 12, 17] {
		{
			{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
			{1,0,0,0,0,0,0,0,3,0,0,0,0,0,0,2,1},
			{1,2,1,1,1,0,1,1,1,0,1,1,1,0,1,1,1},
			{1,1,1,0,1,0,1,0,1,1,2,0,1,0,1,0,1},
			{1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1},
			{1,0,1,0,1,0,1,2,1,0,1,0,1,0,1,0,1},
			{1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1},
			{1,1,1,0,1,0,1,0,1,0,1,0,1,0,1,1,1},
			{1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1},
			{1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1},
			{1,0,0,0,0,0,0,4,1,5,0,0,0,0,0,0,1},
			{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}
		},
		{
			{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
			{1,0,0,0,0,0,0,0,3,0,0,0,0,0,0,0,1},
			{1,0,1,0,1,0,1,1,1,1,1,0,1,0,1,0,1},
			{1,0,1,0,1,0,1,0,1,0,2,1,1,1,1,0,1},
			{1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1},
			{1,0,1,1,2,0,1,1,1,1,1,0,1,0,1,1,1},
			{1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1},
			{1,1,1,0,1,1,1,0,1,0,1,1,1,1,1,2,1},
			{1,0,2,0,1,0,0,0,1,0,0,0,0,0,0,0,1},
			{1,0,1,0,1,0,1,0,2,1,1,0,1,0,1,1,1},
			{1,0,0,0,0,0,1,0,1,0,0,0,0,0,0,0,1},
			{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}
		}
	};
	
	void ClearLevel ()
	{

		foreach (Transform child in transform.root.Find("/Walls").transform) {
			Destroy (child.gameObject);
		}
		foreach (Transform child in transform.root.Find("/Furniture").transform) {
			Destroy (child.gameObject);
		}
	}


	public void BuildLevel ()
	{
		ClearLevel ();
		int m = -8;
		int n = 5;
		for (int i = 0; i < 12; i++) {
			for (int j = 0; j < 17; j++) {
				switch (level [numLevel - 1, i, j]) {
				case 1:
					obj = (GameObject)Instantiate (perfabWall, new Vector3 (m, n, 0), new Quaternion (0, 0, 0, 0));
					obj.transform.parent = obj.transform.root.Find ("/Walls").transform;
					break;
				case 2:
					obj = (GameObject)Instantiate (perfabSecret, new Vector3 (m, n, 0), new Quaternion (0, 0, 0, 0));
					obj.transform.parent = obj.transform.root.Find ("/Furniture").transform;
					break;
				case 3:
					perfabExit.transform.position = new Vector3 (m, n, 0);
					break;
				case 4:
					perfabPlayerL.transform.position = new Vector3 (m, n, 0);
					break;
				case 5:
					perfabPlayerR.transform.position = new Vector3 (m, n, 0);
					break;
				}
				m++;
			}
			m = -8;
			n--;
		}
	}
}
