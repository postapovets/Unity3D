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
		if (state == ' ') {
			state = 'd';
			WWWForm form = new WWWForm ();
			form.AddField ("login", username);
			www = new WWW ("http://letsplay.16mb.com/MySQLTest/details.php", form);
		}
	}

	void Update ()
	{
		// parse results
		if (state == 'r' && www != null && www.isDone) { // register
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
		if (state == 'l' && www != null && www.isDone) { // login
			if (www.error == null) {
				if (www.text == "Ok") {
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
		if (state == 'd' && www != null && www.isDone) { // view mode
			if (www.error == null) {
				for (int i = 0; i < panDetails.transform.childCount; i++) {
					Destroy (panDetails.transform.GetChild (i).gameObject);
				}
				if (www.text != "null") {
					jsonObj = new JSONObject (www.text);
					foreach (var json in jsonObj.list) {
						var data = json.ToDictionary ();
						GameObject obj = (GameObject)Instantiate (txtItem, Vector3.zero, Quaternion.identity);
						obj.transform.SetParent (panDetails.transform);
						string strText = data ["name"].ToString () + ": " + data ["inventcount"];
						obj.transform.Find ("Text").GetComponent<Text> ().text = strText;
					}
				}
			}
			state = ' ';
			www = null;
		}
	}
}
