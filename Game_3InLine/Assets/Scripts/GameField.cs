using UnityEngine;
using System.Collections;

public class GameField : MonoBehaviour
{

	public int dimX;
	public int dimY;
	public GameObject perfabCircle;
	public Color[] colors = {Color.white, Color.green, Color.red, Color.yellow, Color.cyan};

	GameObject[,] gameField;
	GameObject selected1 = null;


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
					if (selected1 == hit.collider.gameObject)
						stopAnimation ();
					iTween.RotateAdd (hit.collider.gameObject, iTween.Hash ("x", 360, "time", 2, "looptype", iTween.LoopType.loop, "easetype", iTween.EaseType.linear));
					if (selected1 == null) {
						selected1 = hit.collider.gameObject;                                          
					} else {
						if (Vector3.Distance (selected1.transform.position, hit.collider.transform.position) == 1) {
							Vector3[] path = new Vector3[] {
							new Vector3 (selected1.transform.position.x, selected1.transform.position.y, selected1.transform.position.z - 1),
							hit.collider.transform.position};
							iTween.MoveTo (selected1, iTween.Hash ("path", path, "easetype", iTween.EaseType.linear));

							path = new Vector3[] {
							new Vector3 (hit.collider.transform.position.x, hit.collider.transform.position.y, hit.collider.transform.position.z + 1),
							selected1.transform.position};
							iTween.MoveTo (hit.collider.gameObject, iTween.Hash ("path", path, "easetype", iTween.EaseType.linear, 
							                                                     "oncomplete", "stopAnimation", "oncompletetarget", hit.collider.transform.parent.gameObject));
							// update array
							for (int i = 0; i < dimX; i++) {
								for (int j = 0; j < dimY; j++) {
									if (gameField [i, j] == selected1)
										gameField [i, j] = hit.collider.gameObject;
									else if (gameField [i, j] == hit.collider.gameObject)
										gameField [i, j] = selected1;
								}
							}
							DropCirles ();
						} else {
							stopAnimation ();
						}
						selected1 = null;
					}
				}
			}
		}
	}

	void stopAnimation ()
	{
		iTween.Stop (gameObject, true);
	}

	void DropCirles ()
	{
		for (int i = 0; i < dimX; i++) {
			for (int j = 0; j < dimY; j++) {
				Color myColor = gameField [i, j].GetComponent<MeshRenderer> ().material.color;
				if (j < dimY - 2) {
					if (gameField [i, j + 1].GetComponent<MeshRenderer> ().material.color == myColor && gameField [i, j + 2].GetComponent<MeshRenderer> ().material.color == myColor) {
						iTween.RotateAdd (gameField [i, j], iTween.Hash ("y", 360, "time", 2, "looptype", iTween.LoopType.loop, "easetype", iTween.EaseType.linear));
						iTween.RotateAdd (gameField [i, j + 1], iTween.Hash ("y", 360, "time", 2, "looptype", iTween.LoopType.loop, "easetype", iTween.EaseType.linear));
						iTween.RotateAdd (gameField [i, j + 2], iTween.Hash ("y", 360, "time", 2, "looptype", iTween.LoopType.loop, "easetype", iTween.EaseType.linear));
					}
				}
				if (i < dimX - 2) {
					if (gameField [i + 1, j].GetComponent<MeshRenderer> ().material.color == myColor && gameField [i + 2, j].GetComponent<MeshRenderer> ().material.color == myColor) {
						iTween.RotateAdd (gameField [i, j], iTween.Hash ("y", 360, "time", 2, "looptype", iTween.LoopType.loop, "easetype", iTween.EaseType.linear));
						iTween.RotateAdd (gameField [i + 1, j], iTween.Hash ("y", 360, "time", 2, "looptype", iTween.LoopType.loop, "easetype", iTween.EaseType.linear));
						iTween.RotateAdd (gameField [i + 2, j], iTween.Hash ("y", 360, "time", 2, "looptype", iTween.LoopType.loop, "easetype", iTween.EaseType.linear));
					}	
				}
			}
		}
	}
}
