using UnityEngine;
using System.Collections;
using System;

public class Server : MonoBehaviour
{
	
	public GameObject PlayerPrefab;	// Перфаб гравця
	public string ip = "127.0.0.1";	// ip для створення чи підключення до сервера
	public string port = "5300";	// Порт
	string nickname = "";	// nickname
	public bool connected;			// Статус підключення
	private GameObject _go;			// силка на гравця
	public bool _visible = false;	// Статус виведення меню

	void Update ()
	{
		//Вмикаємо/вимикаємо меню гри
		if (Input.GetKeyUp (KeyCode.Escape)) 
			_visible = !_visible;
	}

	void OnGUI ()
	{
		// Перевіряємо чи ми на сервері (чи виконалось підключення)
		if (connected) {
			//Перевіряємо чи потрібно відображати меню
			if (_visible) {
				// Виводимо кількість підключених клієнтів
				GUI.Label (new Rect ((Screen.width - 120) / 2, Screen.height / 2 - 35, 120, 30), "Присоединились: " + Network.connections.Length);
				if (GUI.Button (new Rect ((Screen.width - 100) / 2, Screen.height / 2, 100, 30), "Отключиться")) 
					// Розпочинаємо процедуру відключення від сервера
					// 200 = 2 секунди - час протягом якого ще будуть прийматися повідомлення
					// від сервера (час, що необхідно виділити для успішного розєднання)
					Network.Disconnect (200);
				
				if (GUI.Button (new Rect ((Screen.width - 100) / 2, Screen.height / 2 + 35, 100, 30), "Выход"))
					Application.Quit ();
			}
			//Если мы в главном меню
		} else {
			GUI.Label (new Rect ((Screen.width - 100) / 2, Screen.height / 2 - 90, 100, 20), "Nick");
			nickname = GUI.TextField (new Rect ((Screen.width - 100) / 2 + 35, Screen.height / 2 - 90, 100, 20), nickname);
			GUI.Label (new Rect ((Screen.width - 100) / 2, Screen.height / 2 - 60, 100, 20), "Ip");
			GUI.Label (new Rect ((Screen.width - 100) / 2, Screen.height / 2 - 30, 100, 20), "Порт");
			ip = GUI.TextField (new Rect ((Screen.width - 100) / 2 + 35, Screen.height / 2 - 60, 100, 20), ip);
			port = GUI.TextField (new Rect ((Screen.width - 100) / 2 + 35, Screen.height / 2 - 30, 50, 20), port);
			
			if (GUI.Button (new Rect ((Screen.width - 110) / 2, Screen.height / 2, 110, 30), "Присоединиться"))
				// Підключення до сервера
				Network.Connect (ip, Convert.ToInt32 (port));
			
			if (GUI.Button (new Rect ((Screen.width - 110) / 2, Screen.height / 2 + 35, 110, 30), "Создать сервер"))
				// Створення сервера(кількість підключень до сервера, 
				// порт на якомо створити сервер, підключення через посредників)
				Network.InitializeServer (10, Convert.ToInt32 (port), false);
			
			if (GUI.Button (new Rect ((Screen.width - 110) / 2, Screen.height / 2 + 70, 110, 30), "Выход"))
				Application.Quit ();
		}
	}
	
	// Викликається коли ми підключились до сервера
	void OnConnectedToServer ()
	{
		CreatePlayer ();
	}
	
	// Викликається коли ми створили сервер
	void OnServerInitialized ()
	{
		CreatePlayer ();
	}
	
	// Створення гравця
	void CreatePlayer ()
	{
		connected = true;
		// Вимикаємо камеру та аудіо слухача з головної камери
		GetComponent<Camera> ().enabled = false;
		// Створюємо гравця використовуючи клас Network 
		// для забезпечення подальшої синхронізації в мультиплеєрі
		_go = (GameObject)Network.Instantiate (PlayerPrefab, transform.position, transform.rotation, 1);
		// Вмикаємо камеру та аудіо слухача для нашого персонажа
		_go.transform.GetComponentInChildren<Camera> ().GetComponent<Camera> ().enabled = true;
		_go.GetComponent<Client> ().nickname = nickname;
	}
	
	// Викликається при відключенні від cервера
	void OnDisconnectedFromServer (NetworkDisconnection info)
	{
		// Встановлюємо значенна змінної в хибне, що служитиме ознакою того, що
		// ми вже вийшли з сервера
		connected = false;
		// Вмикаємо основну камеру та аудіо слухача 
		GetComponent<Camera> ().enabled = true;
		GetComponent<Camera> ().gameObject.GetComponent<AudioListener> ().enabled = true;
		// Виконуємо перезавантаження сцени
		Application.LoadLevel (Application.loadedLevel);
	}
	
	// Викликається кожного разу коли гравець відключається від сервера
	// pl - гравець, що відключається 
	void OnPlayerDisconnected (NetworkPlayer pl)
	{
		// Завершуємо передачу RPC повідомлень
		Network.RemoveRPCs (pl);
		// Видаляємо гравця 
		Network.DestroyPlayerObjects (pl);
	}
}
