using UnityEngine;
using System.Collections;

public class ParticleDemage : MonoBehaviour
{

	public int Demage = -1;

	void OnParticleCollision (GameObject other)
	{
		if (other.tag == "Player") {
			other.GetComponent<BoxHealth> ().UpdateHealth (Demage);
		}
	}
}
