using UnityEngine;
using System.Collections;
[ExecuteInEditMode]

public class GUIMenu : MonoBehaviour
{

	bool mainMenuShow;
	bool showScore = false;
	bool settingsShow = false;
	bool exitApp = false;
	public float playTime;

	int resID = 0;
	float volume = 50f;
	bool[] inputController = {true, false, false};

	void Start ()
	{
		mainMenuShow = true;

	}

	void Update ()
	{
		if (exitApp) {
			mainMenuShow = true;
			print ("Terminate application");
		}
		if (!mainMenuShow && !showScore && !settingsShow) {
			playTime -= Time.deltaTime;
			if (playTime <= 0) {
				showScore = true;
			}
		}

	}

	void OnGUI ()
	{
		if (mainMenuShow) {
			GUI.Window (0, new Rect (30, 30, Screen.width - 60, Screen.height - 60), GUIMainMenu, "Main menu");
		} else {
			if (!settingsShow)
				mainMenuShow = GUI.Button (new Rect (10, 10, 80, 20), "Menu");
		}
		if (showScore) {
			GUI.Window (0, new Rect (30, 30, Screen.width - 60, Screen.height - 60), GUIScoreWindow, "Score table");
		}
		if (settingsShow) {
			GUI.Window (0, new Rect (30, 30, Screen.width - 60, Screen.height - 60), GUISettingsWindow, "Settings");
		}
	}

	void GUIMainMenu (int id)
	{
		mainMenuShow = !GUI.Button (new Rect (30, 30, 60, 30), "Play");
		settingsShow = GUI.Button (new Rect (30, 70, 60, 30), "Settings");
		exitApp = GUI.Button (new Rect (30, 110, 60, 30), "Exit");
	}

	void GUIScoreWindow (int id)
	{
		int width = Screen.width - 60;
		int height = Screen.height - 60;
		GUI.TextArea (new Rect (10, 20, width - 20, height - 70), "Winners score table");
		mainMenuShow = GUI.Button (new Rect (width - 70, height - 40, 60, 30), "Close");
		showScore = !mainMenuShow;
	}

	void GUIGameOptionsWindow (int id)
	{

	}

	void GUISettingsWindow (int id)
	{
		int width = Screen.width - 80;
		int height = Screen.height - 20;

		GUI.Label (new Rect (10, 20, width, 30), "Screen resolution");
		resID = GUI.Toolbar (new Rect (10, 40, width, 30), resID, new string[] {"640x480", "1024x768", "1920x1280"});

		GUI.Label (new Rect (10, 80, width, 30), "Sound volume");
		volume = GUI.HorizontalSlider (new Rect (10, 100, width, 30), volume, 0, 100);

		GUI.Label (new Rect (10, 130, width, 30), "Input controller");
		if (inputController [0])
			GUI.Toggle (new Rect (10, 150, width, 30), true, " Mouse");
		else
			inputController [0] = GUI.Toggle (new Rect (10, 150, width, 30), inputController [0], " Mouse");
		if (inputController [0]) {
			inputController [1] = false;
			inputController [2] = false;
		}
		if (inputController [1])
			GUI.Toggle (new Rect (10, 170, width, 30), true, " Keyboard");
		else 
			inputController [1] = GUI.Toggle (new Rect (10, 170, width, 30), inputController [1], " Keyboard");
		if (inputController [1]) {
			inputController [0] = false;
			inputController [2] = false;
		}
		if (inputController [2])
			GUI.Toggle (new Rect (10, 190, width, 30), true, " Joystic");
		else
			inputController [2] = GUI.Toggle (new Rect (10, 190, width, 30), inputController [2], " Joystic");
		if (inputController [2]) {
			inputController [0] = false;
			inputController [1] = false;
		}
		


		mainMenuShow = GUI.Button (new Rect (width - 50, height - 80, 60, 30), "Close");
		settingsShow = !mainMenuShow;
	}
}
