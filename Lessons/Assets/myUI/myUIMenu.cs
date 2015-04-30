using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;


public class myUIMenu : MonoBehaviour
{

	Animator myAnim;
	// Use this for initialization
	void Start ()
	{
		myAnim = GetComponent<Animator> ();
	}

	public void btnPlayClick ()
	{
		btnExitClick ();
		print ("Play");
	}

	public void btnExitClick ()
	{
		myAnim.SetBool ("MainMenuOpen", false);
	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (!myAnim.GetBool ("MainMenuOpen")) {
				myAnim.SetBool ("MainMenuOpen", true);

			}
		}
	}

	public void btnSettingsClick ()
	{
		myAnim.SetBool ("SettingsOpen", true);
	}

	public void btnCloseClick ()
	{
		myAnim.SetBool ("SettingsOpen", false);
	}
}
