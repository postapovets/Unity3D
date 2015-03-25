using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

	// Use this for initialization
	public Color destColor;
	void Start ()
	{
		destColor = transform.GetComponent<MeshRenderer> ().material.color;
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.GetComponent<MeshRenderer> ().material.color = Color.Lerp (transform.GetComponent<MeshRenderer> ().material.color, destColor, 0.1f);
	}
}
