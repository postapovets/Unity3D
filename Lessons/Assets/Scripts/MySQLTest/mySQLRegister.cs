using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class mySQLRegister : MonoBehaviour
{

	public InputField txtLogin;
	public InputField txtPassword;

	WWW www;
	char state = ' ';

	public void onRegClick ()
	{
		if (state == ' ' && txtLogin.text.Length > 0 && txtPassword.text.Length > 0) {
			state = 'r';
			WWWForm form = new WWWForm ();
			form.AddField ("login", txtLogin.text);
			form.AddField ("password", txtPassword.text);
			www = new WWW ("http://letsplay.16mb.com/MySQLTest/register.php", form);
		}
	}

	public void onLoginClick ()
	{
		if (state == ' ' && txtLogin.text.Length > 0 && txtPassword.text.Length > 0) {
			state = 'l';
			WWWForm form = new WWWForm ();
			form.AddField ("login", txtLogin.text);
			form.AddField ("password", txtPassword.text);
			www = new WWW ("http://letsplay.16mb.com/MySQLTest/login.php", form);
		}
	}

	void Update ()
	{
		// parse results
		if (www != null && www.isDone && state == 'r') { // register
			if (www.error == null) {
				if (www.text == "Ok") {
					print ("User registered.");
				} else {
					print ("Error. Result = " + www.text);
				}
			}
			state = ' ';
			www = null;
		}
		if (www != null && www.isDone && state == 'l') { // login
			if (www.error == null) {
				if ("Ok".Equals (www.text)) {
					print ("Login Ok");
				} else {
					print ("Error. Result = " + www.text);
				}
			}
			state = ' ';
			www = null;
		}
	}
}
