using UnityEngine;
using System.Collections;

public class Task2 : MonoBehaviour
{

	public GameObject obj;

	public static GameObject[,] squares = new GameObject[6, 6];

	// Use this for initialization
	void Start ()
	{
		for (int i = 0; i < 6; i++) {
			for (int j = 0; j < 6; j++) {
				squares [i, j] = (GameObject)Instantiate (obj, new Vector3 (i - 3, j - 3, 0f), new Quaternion (0f, 0f, 0f, 0f));
				squares [i, j].name = "square" + i + "_" + j;
			}
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
