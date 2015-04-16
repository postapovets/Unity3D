using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour
{
	public float radius = 5.0F;
	public float power = 10.0F;

	void OnParticleCollision (GameObject other)
	{

		Vector3 explosionPos = transform.position;
	
		
		if (other.tag == "Sphere") {
			//	Vector3 wave = Vector3.Lerp (gameObject.transform.position, other.transform.position, 0.5f);
			other.GetComponent<Rigidbody> ().AddExplosionForce (power, explosionPos, radius, 0, ForceMode.Impulse);
		}
	}
}
