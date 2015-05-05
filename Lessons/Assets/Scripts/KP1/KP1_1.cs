using UnityEngine;
using System.Collections;

public class KP1_1 : MonoBehaviour
{

	public int num;

	private int num1;
	private int num2;

	void Start ()
	{
		string str = num.ToString ();
		if (str.Length == 4) {
			num1 = int.Parse (str [0].ToString ()) + int.Parse (str [1].ToString ());
			num2 = int.Parse (str [2].ToString ()) + int.Parse (str [3].ToString ());
			if (num1 == num2) {
				print ("Number is lucky! You win!");
			} else {
				print ("Number isn't lucky. Try again.");
			}
		} else {
			print ("Not 4 digits number entered. Calculation stoped.");
		}
	}
}
