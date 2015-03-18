using UnityEngine;
using System.Collections;

public class Task1 : MonoBehaviour
{
	
	float randomTime;
	float timer1 = 0;
	bool msgPrinted = false;
	public GameObject pers;
	public static float GameTimer = 20;
	public static int Counter = 0;

	// Use this for initialization
	void Start ()
	{
		randomTime = Random.Range (1f, 3f);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (GameTimer > 0) {
			GameTimer -= Time.deltaTime;
			timer1 += Time.deltaTime;
			if (timer1 > randomTime) {
				randomTime = Random.Range (1f, 3f); // generate new random timer
				timer1 = 0;

				pers = (GameObject)Instantiate (pers, new Vector3 (Random.Range (-5f, 5f), 
					                            Random.Range (-5f, 5f), 
					                            Random.Range (-5f, 5f)), new Quaternion (0f, 0f, 0f, 0f));
				pers.transform.parent = gameObject.transform;
			}
		} else if (! msgPrinted) {  // print message one time
			Destroy (gameObject);
			print ("Counter = " + Counter);
			msgPrinted = true;
		}
	}
	
}
