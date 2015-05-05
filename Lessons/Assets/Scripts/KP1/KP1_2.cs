using UnityEngine;
using System.Collections;

public class KP1_2 : MonoBehaviour
{

	private float sum = 0;
	private int n;

	void Start ()
	{
		n = Random.Range (6, 20);
		for (int i = 1; i < n+1; i++) {
			sum += 1f / i;
		}
		print (string.Format ("n = {0}, sum = {1}", n, sum));
	}

}
