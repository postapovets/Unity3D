using UnityEngine;
using System.Collections;

public class Behaivor : MonoBehaviour
{

	Vector3 moveVector;
	float rndSpriteTimer;
	float timerSprite = 0;
	public Sprite[] sprites = new Sprite[4];

	// Use this for initialization
	void Start ()
	{
		moveVector = new Vector3 (Random.Range (-0.01f, 0.01f), 
		                          Random.Range (-0.01f, 0.01f), 
		                          Random.Range (-0.01f, 0.01f));
		rndSpriteTimer = Random.Range (1, 3);
		GetComponent<SpriteRenderer> ().sprite = sprites [Random.Range (0, 4)];
	}
	
	// Update is called once per frame
	void Update ()
	{

		gameObject.transform.position += moveVector;

		timerSprite += Time.deltaTime;
		if (timerSprite > rndSpriteTimer) { // change sprite image
			GetComponent<SpriteRenderer> ().sprite = sprites [Random.Range (0, 4)];
			timerSprite = 0;
		}

	}

	void OnMouseDown ()
	{
		if (GetComponent<SpriteRenderer> ().sprite.name == "spongebob") {
			Task1.Counter += 3;
			if (gameObject != null)
				Destroy (gameObject);
		} else {
			Task1.Counter--;
		}
	}
}
