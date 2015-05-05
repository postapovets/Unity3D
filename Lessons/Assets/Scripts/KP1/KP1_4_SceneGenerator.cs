using UnityEngine;
using System.Collections;

public class KP1_4_SceneGenerator : MonoBehaviour
{
	public int numBonus;
	public GameObject bonus;
	public int numObstacle;
	public GameObject obstacle;

	void Start ()
	{
		for (int i = 0; i < numBonus; i++) {
			Instantiate (bonus, new Vector3 (Random.Range (-4.5f, 4.5f), 0.3f, Random.Range (-4.5f, 4.5f)), Quaternion.identity);
		}
		for (int i = 0; i < numObstacle; i++) {
			Instantiate (obstacle, new Vector3 (Random.Range (-4.5f, 4.5f), 0.3f, Random.Range (-4.5f, 4.5f)), Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
