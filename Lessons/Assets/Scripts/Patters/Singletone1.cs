using UnityEngine;
using System.Collections;

public class Singletone1 : MonoBehaviour
{
	public static Singletone1 singletone { get; private set; }


	private int counter = 0;
	void Awake ()
	{
		singletone = this;
	}

	public void AddCoin (int coin)
	{
		counter += coin;
	}

	public int GetCoins ()
	{
		return counter;
	}
}
