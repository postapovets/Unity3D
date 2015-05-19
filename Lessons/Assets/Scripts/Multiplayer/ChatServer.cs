using UnityEngine;
using System.Collections;

public class CharServer : MonoBehaviour
{
	public string ip = "127.0.0.1";
	public string port = "5000";
	public bool conect = false;
	public static string text = "";
	public GameObject Client;
	public static bool ser = false;
	
	// Use this for initialization
	void OnGUI ()
	{
		GUI.Label (new Rect ((Screen.width - 120) / 2, Screen.height / 2 - 120, 120, 30), "Online: " + Network.connections.Length);
		if (!conect) {
			ip = GUI.TextField (new Rect ((Screen.width - 120) / 2, Screen.height / 2 - 90, 120, 30), ip);
			port = GUI.TextField (new Rect ((Screen.width - 120) / 2, Screen.height / 2 - 60, 120, 30), port);
			
			if (GUI.Button (new Rect ((Screen.width - 110) / 2, Screen.height / 2, 110, 30), "Connect")) {
				Network.Connect (ip, int.Parse (port));
				ser = false;
			}
			
			if (GUI.Button (new Rect ((Screen.width - 110) / 2, Screen.height / 2 - 30, 110, 30), "New server")) {
				Network.InitializeServer (5, int.Parse (port), false);
				ser = true;
			}
			
		} else {
			if (GUI.Button (new Rect ((Screen.width - 100) / 2, Screen.height / 2 - 90, 110, 30), "Disconnect")) {
				Network.Disconnect (200);
			}
			GUI.TextArea (new Rect ((Screen.width - 120) / 2, Screen.height / 2 - 60, 200, 100), text);
		}
	}
	
	void OnConnectedToServer ()
	{
		conect = true;
		Network.Instantiate (Client, Vector3.zero, Quaternion.identity, 0);
	}
	
	void OnServerInitialized ()
	{
		conect = true;
		Network.Instantiate (Client, Vector3.zero, Quaternion.identity, 0);
	}
	
	void OnDisconnectedFromServer (NetworkDisconnection nd)
	{
		conect = false;
		Application.LoadLevel (Application.loadedLevel);
	}
	
	void OnPlayerDisconnected (NetworkPlayer np)
	{
		Network.RemoveRPCs (np);
		Network.DestroyPlayerObjects (np);
	}

}
