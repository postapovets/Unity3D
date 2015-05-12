using UnityEngine;
using System.Collections;

public class mySQLTest : MonoBehaviour
{
	WWW www;
	JSONObject jsonObj;
	char state = ' ';
	int score = 1;

	void Update ()
	{
		// start operations
		if (Input.GetKeyDown (KeyCode.I)) { // insert/update record
			state = 'i';
			print ("Begin insert");
			WWWForm form = new WWWForm ();
			form.AddField ("name", "jsmith");
			form.AddField ("level", 1);
			form.AddField ("score", score++);
			www = new WWW ("http://letsplay.16mb.com/Unity3DTest/setuser.php", form);
		}
		if (Input.GetKeyDown (KeyCode.S)) { // select all records
			state = 's';
			print ("Begin select");
			www = new WWW ("http://letsplay.16mb.com/Unity3DTest/getuser.php");
		}

		// parse results
		if (www != null && www.isDone && state == 'i') { // insert record done
			print ("Done insert" + www.text);
			state = ' ';
			www = null;
		}
		if (www != null && www.isDone && state == 's') { // select done
			print ("Select finished");
			if (www.error == null) {
				jsonObj = new JSONObject (www.text);
				foreach (var json in jsonObj.list) {
					var data = json.ToDictionary ();
					print (data ["name"] + " " + data ["level"] + " " + data ["score"]);
				}
			}
			state = ' ';
			www = null;
		}

	}
}
