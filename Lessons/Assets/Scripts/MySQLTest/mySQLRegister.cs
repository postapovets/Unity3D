using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class mySQLRegister : MonoBehaviour
{

	public InputField txtLogin;
	public InputField txtPassword;
	public GameObject dlgLogin;
	public GameObject dlgUsers;
	public GameObject btnUser;
	public GameObject txtItem;
	public GameObject panUsers;
	public GameObject panDetails;

	WWW www;
	JSONObject jsonObj;
	char state = ' ';

	void Start ()
	{
		dlgLogin.SetActive (true);
		dlgUsers.SetActive (false);
	}

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

	void GetUsers ()
	{
		if (state == 'v') {
			www = new WWW ("http://letsplay.16mb.com/MySQLTest/getuser.php");
		}
	}

	public void onUserClick (string username)
	{
		state = 'd';
		WWWForm form = new WWWForm ();
		form.AddField ("login", txtLogin.text);
		www = new WWW ("http://letsplay.16mb.com/MySQLTest/details.php", form);
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
					dlgLogin.SetActive (false);
					dlgUsers.SetActive (true);
					state = 'v';
					GetUsers ();
				} else {
					print ("Error. Result = " + www.text);
				}
			}
			if (state == 'l') {
				state = ' ';
				www = null;
			}
		}
		if (state == 'v' && www != null && www.isDone) { // view mode
			if (www.error == null) {
				jsonObj = new JSONObject (www.text);
				foreach (var json in jsonObj.list) {
					var data = json.ToDictionary ();
					GameObject obj = (GameObject)Instantiate (btnUser, Vector3.zero, Quaternion.identity);
					obj.transform.SetParent (panUsers.transform);
					string login = data ["login"].ToString ();
					obj.transform.Find ("Text").GetComponent<Text> ().text = login;
					obj.GetComponent<Button> ().onClick.AddListener (() => {
						onUserClick (login);});
				}
			}
			state = ' ';
			www = null;
		}
	}
}
