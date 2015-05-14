using UnityEngine;
using System.Collections;

public class mySQLScene : MonoBehaviour
{
	WWW www;
	JSONObject jsonObj;
	char state = ' ';
	int score = 1;

	void Update ()
	{
		// start operations
		if (Input.GetKeyDown (KeyCode.S)) { // save scene
			state = 's';
			for (int i = 0; i < transform.childCount; i++) {
				Transform child = transform.GetChild (i);
				WWWForm form = new WWWForm ();
				form.AddField ("name", child.name);
				form.AddField ("posX", child.position.x.ToString ());
				form.AddField ("posY", child.position.y.ToString ());
				form.AddField ("posZ", child.position.z.ToString ());
				www = new WWW ("http://letsplay.16mb.com/MySQLTest/saveScene.php", form);
			}
		}

		if (Input.GetKeyDown (KeyCode.L)) { // select all records
			state = 'l';
			www = new WWW ("http://letsplay.16mb.com/MySQLTest/loadScene.php");
		}

		// parse results
		if (www != null && www.isDone && state == 's') { // save done
			state = ' ';
			www = null;
		}
		if (www != null && www.isDone && state == 'l') { // select done
			if (www.error == null) {
				jsonObj = new JSONObject (www.text);
				foreach (var json in jsonObj.list) {
					var data = json.ToDictionary ();
					Transform child = transform.Find (data ["name"]);
					if (child != null) {
						child.position = new Vector3 (float.Parse (data ["posX"]),
						                                       float.Parse (data ["posY"]),
						                                       float.Parse (data ["posZ"]));
					}
				}
			}
			state = ' ';
			www = null;
		}

	}
}
