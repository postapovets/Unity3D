using UnityEngine;
using System.Collections;

public class androidMove : MonoBehaviour
{
	public GameObject camDir;
	public GameObject camRot;

	Vector3 zoomMin = new Vector3 (0, 3.3f, -5f);
	Vector3 zoomMax = new Vector3 (0, 13f, -20f);

	float t = 0.5f;
	float prevDist = 0;

	bool isZoom = false;


	Rigidbody myBody;

	void Start ()
	{
		myBody = GetComponent<Rigidbody> ();
		Camera.main.transform.localPosition = Vector3.Lerp (zoomMin, zoomMax, t);
	}
	
	void FixedUpdate ()
	{
		camDir.transform.position = transform.position;
		Vector3 accel = Input.acceleration;

		myBody.AddForce (camDir.transform.TransformDirection (accel.x * 40, 0, (accel.y + 0.0f) * 60));
		// Camera moving
		if (Input.touchCount == 1) {
			if (Input.GetTouch (0).phase == TouchPhase.Moved) {
				camDir.transform.Rotate (0, Input.GetTouch (0).deltaPosition.x * 0.5f, 0, Space.World);
				camRot.transform.Rotate (-Input.GetTouch (0).deltaPosition.y * 0.5f, 0, 0, Space.Self);
			}
		}

		// Camera zoom
		if (Input.touchCount == 2) {
			if (Input.GetTouch (0).phase == TouchPhase.Moved || Input.GetTouch (1).phase == TouchPhase.Moved) {
				if (isZoom) {
					float dist = Vector2.Distance (Input.GetTouch (0).position, Input.GetTouch (1).position);

					if (prevDist > dist) { //zoom out
						t += dist / prevDist * 0.05f;
					}
					if (prevDist < dist) { //zoom in
						t -= prevDist / dist * 0.05f;
					}
					if (t > 1)
						t = 1f;
					if (t < 0)
						t = 0f;

					Camera.main.transform.localPosition = Vector3.Lerp (zoomMin, zoomMax, t);
				} else {
					isZoom = true;
					prevDist = Vector2.Distance (Input.GetTouch (0).position, Input.GetTouch (1).position);
				}
			}
		} else {
			isZoom = false;
		}
	}

}
