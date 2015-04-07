using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Parallax : MonoBehaviour
{
	private float parallaxSpeedX;
	private float parallaxSpeedY;
	private float positionY;

	public Transform[] paralax;

	void Start ()
	{
		positionY = transform.position.y;
	}

	void Update ()
	{
		// move sky
		for (int i = 0; i < 2; i++) {
			paralax [i].transform.position += new Vector3 (0.005f, 0, 0);
		}
		UpdateParallax ();

	}

	void UpdateParallax ()
	{
		float k = 0.01f;

		parallaxSpeedY = transform.position.y - positionY;
		if (Mathf.Abs (parallaxSpeedY) < 0.01f)
			parallaxSpeedY = 0;

		parallaxSpeedX = Input.GetAxis ("Horizontal");
	
		if (Mathf.Abs (parallaxSpeedX) > 0.1f || Mathf.Abs (parallaxSpeedY) > 0.01f) {
			for (int i = 0; i < paralax.Length; i++) {
				if (i % 2 == 0)
					k *= 2;
				paralax [i].position -= new Vector3 (parallaxSpeedX * k, parallaxSpeedY * k, 0);
				if (paralax [i].localPosition.x < -18) {
					paralax [i].localPosition += new Vector3 (40, 0, 0);
				}
				if (paralax [i].localPosition.x > 22) {
					paralax [i].localPosition -= new Vector3 (40, 0, 0);
				}
			}
		}
		positionY = transform.position.y;
	}
}
