using UnityEngine;
using System.Collections;

public class Detector : MonoBehaviour
{

	public GameObject AlarmLight;


	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player") {
			if (!AlarmLight.activeSelf) {
				AlarmLight.SetActive (true);
			}
		}
	}
}
