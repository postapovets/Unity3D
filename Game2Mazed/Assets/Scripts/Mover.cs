using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
	public Rigidbody2D PlayerL;
	public Rigidbody2D PlayerR;
	public GameObject Portal;
	public TextMesh txtGameOver;
	public int speed;
	SceneGenerator sceneGenerator;
	int gameLevel = 1;
	bool gameOver;

	void Start ()
	{
		transform.GetComponent<SceneGenerator> ().BuildLevel (gameLevel);
		gameOver = false;
	}

	void FixedUpdate ()
	{
		if (!gameOver) {
			if (Portal.GetComponent<GameOver> ().MyGameOver) {
				gameOver = true;
				txtGameOver.text = "All Done";
				Portal.gameObject.SetActive (false);
				PlayerL.gameObject.SetActive (false);
				PlayerR.gameObject.SetActive (false);
			}
		}
	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Return)) {
			gameLevel++;
			transform.GetComponent<SceneGenerator> ().BuildLevel (gameLevel);
			txtGameOver.text = "";
			gameOver = false;
		}
	}
}
