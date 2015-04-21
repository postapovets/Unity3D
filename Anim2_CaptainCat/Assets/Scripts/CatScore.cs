using UnityEngine;
using System.Collections;

public class CatScore : MonoBehaviour
{
	public int Health = 3;
	public int Score = 0;
	public int LevelNo = 0;

	private static CatScore _catObj;
	public static CatScore catObj {
		get {
			if (_catObj == null) {
				_catObj = GameObject.FindObjectOfType<CatScore> ();
				DontDestroyOnLoad (_catObj.gameObject);
			}
			return _catObj;
		}
	}

	void Awake ()
	{
		if (_catObj == null) {
			_catObj = this;
			DontDestroyOnLoad (_catObj.gameObject);
		} else if (this != _catObj) {
			Destroy (this.gameObject);
		}
	}
}
