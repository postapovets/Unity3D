using UnityEngine;
using System.Collections;

public class balc : MonoBehaviour
{
	float timer = 5f;
	float stime, sdelay, lstime;
	Vector3 startPos = Vector3.zero, endPos = Vector3.zero;

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		timer -= Time.deltaTime;
		if (GetComponent<NetworkView> ().isMine) {
			if (timer < 0) {
				Network.Destroy (gameObject);
			}
		} else {
			stime += Time.deltaTime;
			transform.position = Vector3.Lerp (startPos, endPos, stime / sdelay);
		}
	}

	void OnSerializeNetworkView (BitStream stream, NetworkMessageInfo info)
	{
		Vector3 spos = Vector3.zero;
		if (stream.isWriting) {
			spos = transform.position;
			stream.Serialize (ref spos);
		} else {
			stream.Serialize (ref spos);
			stime = 0;
			sdelay = Time.time - lstime;
			lstime = Time.time;

			startPos = transform.position;
			endPos = spos;

		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player") {
			other.GetComponent<Client> ().health -= 20;
//			Network.Destroy (gameObject);
		}
	}
}
