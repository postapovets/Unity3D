using UnityEngine;
using System.Collections;

public class cubeV3Rand : MonoBehaviour
{

	public Vector3 v1;
	public Vector3 v2;
	public GameObject SphereObj;
	public float[] f = new float[3];

	float timer = 0;
	GameObject[] spheres = new GameObject[1000];
	Vector3[] dests = new Vector3[1000];
	// Use this for initialization
	void Start ()
	{
		transform.position = v1 + v2 / 2;
		transform.localScale = v1 - v2;
		for (int i = 0; i < spheres.Length; i++) {
			spheres [i] = (GameObject)Instantiate (SphereObj, v1.RandomV3 (v1, v2), Quaternion.identity);
		}
		MoveSpheres ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (timer < 1) {
			timer += Time.deltaTime;
			for (int i = 0; i < spheres.Length; i++) {
				spheres [i].transform.position = Vector3.Lerp (spheres [i].transform.position, dests [i], 0.1f);
			}
		} else {
			MoveSpheres ();
			timer = 0;
		}
	}

	void MoveSpheres ()
	{
		for (int i = 0; i < dests.Length; i++) {
			dests [i] = v1.RandomV3 (v1, v2);
		}
	}
}
