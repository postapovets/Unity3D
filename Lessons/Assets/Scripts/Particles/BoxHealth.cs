using UnityEngine;
using System.Collections;

public class BoxHealth : MonoBehaviour
{

	// Use this for initialization

	public int Health;

	private float showHealth = 0f;
	void Start ()
	{
		Health = 99;
		UpdateHealth ();
	}
	
	public void UpdateHealth (int delta=0)
	{
		if (Health > 0) {
			Health += delta;
			transform.FindChild ("health").GetComponent<TextMesh> ().text = Health.ToString ();
			showHealth = 0f;
		} else {
			Destroy (gameObject);
		}
	}

	void Update ()
	{
		if (showHealth < 1f) {
			showHealth += Time.deltaTime;
			Color txtColor = Color.white;
			txtColor.a -= showHealth;
			transform.FindChild ("health").GetComponent<TextMesh> ().color = txtColor;
		}
	}
}
