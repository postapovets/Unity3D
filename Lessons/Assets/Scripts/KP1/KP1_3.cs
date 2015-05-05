using UnityEngine;
using System.Collections;

public class KP1_3 : MonoBehaviour
{
	public int a;
	public int b;
	public int[] mas1;

	private int sum = 0;


	void Start ()
	{
		for (int i = 0; i < mas1.Length; i++) {
			if (mas1 [i] % a == 0 || mas1 [i] % b == 0) {
				sum += mas1 [i];
			}
		}
		print ("sum = " + sum);
	}

}
