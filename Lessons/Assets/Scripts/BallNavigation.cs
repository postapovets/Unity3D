using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallNavigation : MonoBehaviour
{
	public Text scoreText;
	public GameObject Destination;

	private int score = 0;
	private NavMeshAgent navAgent;

	void Start ()
	{
		navAgent = GetComponent<NavMeshAgent> ();
	}

	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, 100f)) {
				navAgent.SetDestination (hit.point);
				Destination.transform.position = navAgent.destination;
			}
		}
		// Random moving
		/*
		if (Mathf.Abs (Vector3.Distance (navAgent.velocity, new Vector3 (0, 0, 0))) < 0.1f) {
			navAgent.SetDestination(new Vector3 (Random.Range (-8f, 8f), 1f, Random.Range (-8f, 8f)));
			Destination.transform.position = navAgent.destination;
		}
		*/
		if (Mathf.Abs (Vector3.Distance (navAgent.velocity, new Vector3 (0, 0, 0))) < 0.1f) {
			GameObject[] coins = GameObject.FindGameObjectsWithTag ("Coin");
			if (coins.Length > 0) {
				NavMeshPath path = new NavMeshPath ();
				Vector3 dest = coins [0].transform.position;
				NavMesh.CalculatePath (transform.position, coins [0].transform.position, NavMesh.AllAreas, path);
				float minPathLength = CalculateLength (path);
				
				foreach (var coin in coins) {
					NavMesh.CalculatePath (transform.position, coin.transform.position, NavMesh.AllAreas, path);
					float pathLength = CalculateLength (path);
					if (pathLength < minPathLength) {
						minPathLength = pathLength;
						dest = coin.transform.position;
					}
				}
				
				navAgent.SetDestination (dest);
				Destination.transform.position = navAgent.destination;
			}
		}
	}

	float CalculateLength (NavMeshPath path)
	{
		float result = 0;

		for (int i = 0; i < path.corners.Length-1; i++) {
			result += Vector3.Distance (path.corners [i], path.corners [i + 1]);
		}

		return result;
	}

	void OnTriggerEnter (Collider other)
	{
		switch (other.tag) {
		case "Coin":
			score++;
			Destroy (other.gameObject);
			break;
		case "Poison":
			score--;
			Destroy (other.gameObject);
			break;
		}
		scoreText.text = "Score: " + score;
	}
}
