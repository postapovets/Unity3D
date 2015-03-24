using UnityEngine;
using System.Collections;

public class Task10 : MonoBehaviour
{
	public Camera LeftCam;
	public Camera RightCam;

	Vector2 vDestL = new Vector2 (-0.7f, 0.7f);
	Vector2 vDestR = new Vector2 (0.7f, 0.7f);
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		Camera actCam = Camera.main;

		// activate camera
		if (Input.GetKey (KeyCode.Alpha1)) {
			actCam = LeftCam;
		}
		if (Input.GetKey (KeyCode.Alpha2)) {
			actCam = RightCam;
		}

		// move active camera
		if (Input.GetMouseButton (0)) {
			actCam.transform.position += new Vector3 (Input.GetAxis ("Mouse X"), Input.GetAxis ("Mouse Y"), 0);
		}

		// rotate active camera
		if (Input.GetMouseButton (1)) {
			actCam.transform.Rotate (new Vector3 (Input.GetAxis ("Mouse Y"), Input.GetAxis ("Mouse X"), 0));
		}

		//maximize/minimize cameras
		if (Input.GetKeyDown (KeyCode.F1)) {
			if (vDestL.x != 0) {
				vDestL = new Vector2 (0f, 0f);
				vDestR = new Vector2 (0.7f, 0.7f);
			} else
				vDestL = new Vector2 (-0.7f, 0.7f);
		}
		if (Input.GetKeyDown (KeyCode.F2)) {
			if (vDestR.x != 0) {
				vDestR = new Vector2 (0f, 0f);
				vDestL = new Vector2 (-0.7f, 0.7f);
			} else
				vDestR = new Vector2 (0.7f, 0.7f);
		}

		Vector2 vSrcL = new Vector2 (LeftCam.rect.x, LeftCam.rect.y);
		LeftCam.rect = new Rect (Vector2.Lerp (vSrcL, vDestL, 0.05f).x, 
		                         Vector2.Lerp (vSrcL, vDestL, 0.05f).y, 1f, 1f);
		Vector2 vSrcR = new Vector2 (RightCam.rect.x, RightCam.rect.y);
		RightCam.rect = new Rect (Vector2.Lerp (vSrcR, vDestR, 0.05f).x,
		                          Vector2.Lerp (vSrcR, vDestR, 0.05f).y, 1f, 1f);
	}
}

