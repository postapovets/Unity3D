using UnityEngine;
using System.Collections;

public class btnNGUI : MonoBehaviour
{
	public UIPanel mainMenu;
	public UIPanel settingsMenu;
	public UIPanel scoreMenu;
	public UIPanel inGamePanel;
	public UISlider slider;

	public float playTime;
	float currentTime;
	bool inGame = false;

	void Update ()
	{
		if (inGame) {
			if (currentTime > 0) {
				currentTime -= Time.deltaTime;
				slider.value = 1 - currentTime / playTime;
			} else {
				inGame = false;
				inGamePanel.gameObject.SetActive (false);
				scoreMenu.gameObject.SetActive (true);
			}
		}
	}

	public void btnExitClick ()
	{
		print ("Exit clicked!");
	}

	public void btnCloseClick ()
	{
		settingsMenu.gameObject.SetActive (false);
		scoreMenu.gameObject.SetActive (false);
		mainMenu.gameObject.SetActive (true);
		mainMenu.enabled = true;
	}

	public void btnSettingsClick ()
	{
		mainMenu.gameObject.SetActive (false);
		settingsMenu.gameObject.SetActive (true);
	}

	public void btnPlayClick ()
	{
		playTime = 3f;
		currentTime = playTime;
		inGame = true;
		mainMenu.enabled = false;
		inGamePanel.gameObject.SetActive (true);
	}
}
