using UnityEngine;
using System.Collections;

public class ChatClient : MonoBehaviour
{
	public string mes = "", load = "";
	char[] mas = new char[50];
	int lmas;
	NetworkView nv;
	bool pov = false;
	
	// Use this for initialization
	void Start ()
	{
		nv = GetComponent<NetworkView> ();
	}
	
	void OnGUI ()
	{
		if (nv.isMine) {
			mes = GUI.TextField (new Rect ((Screen.width - 80) / 2, Screen.height / 2 + 40, 140, 30), mes);
			if (GUI.Button (new Rect ((Screen.width - 70) / 2, Screen.height / 2 + 70, 40, 30), "ok")) {
				pov = true;
			}
		}
	}
	
	void OnSerializeNetworkView (BitStream strim, NetworkMessageInfo info)
	{
		if (strim.isWriting) {
			bool flag = pov || (ChatServer.ser && load != "");
			strim.Serialize (ref flag);
			if (flag) {
				//strim.Serialize (ref pov);
				if (pov) {
					mas = mes.ToCharArray ();
				} else {
					mas = load.ToCharArray ();
				}
				lmas = mas.Length;
				strim.Serialize (ref lmas);
				for (int i=0; i<lmas; i++) {
					strim.Serialize (ref mas [i]);
				}
				if (pov)
					ChatServer.text += mes + "\n";
				mes = "";
				pov = false;
			}
		} else {
			strim.Serialize (ref pov);
			if (pov) {
				mes = "";
				strim.Serialize (ref lmas);
				for (int i=0; i<lmas; i++) {
					strim.Serialize (ref mas [i]);
					mes += mas [i];
				}
				ChatServer.text += mes + "\n";
				load = mes;
				mes = "";
				pov = false;
			}
		}
	}

}
