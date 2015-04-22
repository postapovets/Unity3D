using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
	[System.Flags]
	enum Health
	{
		Poisoned = 1 << 0,
		Elated = 1 << 1,
		Sloved = 1 << 2
	}

	Health status;

	float timerPoisoned = 0;
	float timerElated = 0;
	float timerSloved = 0;


	public Text txtHealth;
	private float health;
	
	void Start ()
	{
		getDemage (100);
	}

	void Update ()
	{
		if ((status & Health.Poisoned) == Health.Poisoned) {
			getDemage (-Time.deltaTime);
			timerPoisoned += Time.deltaTime;
			if (timerPoisoned > 5) {
				status &= ~ Health.Poisoned;
				timerPoisoned = 0;
			}
		}
		if ((status & Health.Elated) == Health.Elated) {
			getDemage (Time.deltaTime);
			timerElated += Time.deltaTime;
			if (timerElated > 5) {
				status &= ~ Health.Elated;
				timerElated = 0;
			}
		}
	}
	
	void OnParticleCollision (GameObject other)
	{
		if (other.tag == "BadFire") {
			status |= Health.Poisoned;
		}
			
		if (other.tag == "GoodFire") {
			status |= Health.Elated;
		}
	}
	
	void getDemage (float demage)
	{
		health += demage;
		txtHealth.text = string.Format ("Health: {0:0.0}", health);
	}
}
