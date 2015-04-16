using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
	public Text txtHealth;
	
	private int health;
	
	void Start ()
	{
		getDemage (100);
	}
	
	void OnParticleCollision (GameObject other)
	{
		if (other.tag == "BadFire") {
			getDemage (-1);
		}
		
		if (other.tag == "GoodFire") {
			getDemage (1);
		}
	}
	
	void getDemage (int demage)
	{
		health += demage;
		txtHealth.text = "Health: " + health;
	}
}
