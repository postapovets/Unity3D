using UnityEngine;
using System.Collections;

public class GameField : MonoBehaviour
{

	public int dimX;
	public int dimY;
	public GameObject perfabCircle;
	public Color[] colors = {Color.white, Color.green, Color.red, Color.yellow, Color.cyan};

	GameObject[,] gameField;


	// Use this for initialization
	void Start ()
	{
		gameField = new GameObject[dimX, dimY];
		for (int i = 0; i < dimX; i++) {
			for (int j = 0; j < dimY; j++) {
				gameField [i, j] = (GameObject)Instantiate (perfabCircle, new Vector3 (i, j, 0), new Quaternion (0, 0, 0, 0));
				gameField [i, j].name = "c_" + i + "_" + j;
				gameField [i, j].transform.parent = gameObject.transform;
				gameField [i, j].GetComponent<MeshRenderer> ().material.color = colors [Random.Range (0, 5)];
			}
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, 100f)) {
				if (hit.collider.tag == "circle") {
					hit.collider.GetComponent<MeshRenderer> ().material.color = Color.clear;
				}
			}
		}
	}
}
