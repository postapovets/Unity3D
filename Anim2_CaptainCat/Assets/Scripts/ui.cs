using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ui : MonoBehaviour
{

	int levelNo = -1;
	int score = -1;
	int health = -1;
	Text txtLevel;
	Text txtScore;
	Text txtHealth;


	void Start ()
	{
		txtLevel = transform.FindChild ("LevelNo").GetComponent<Text> ();
		txtScore = transform.FindChild ("Score").GetComponent<Text> ();
		txtHealth = transform.FindChild ("Health").GetComponent<Text> ();
	}
	
	void Update ()
	{
		if (levelNo != CatScore.catObj.LevelNo) {
			levelNo = CatScore.catObj.LevelNo;
			txtLevel.text = "Level " + levelNo;
		}
		if (score != CatScore.catObj.Score) {
			score = CatScore.catObj.Score;
			txtScore.text = "Score: " + score;
		}
		if (health != CatScore.catObj.Health) {
			health = CatScore.catObj.Health;
			txtHealth.text = "Health: " + health;
		}
	}
}
