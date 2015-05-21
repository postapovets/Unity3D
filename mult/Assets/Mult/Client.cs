using UnityEngine;
using System.Collections;

public class Client: MonoBehaviour
{
	public GameObject bal;
	public Camera cam;				// Силка на нашу камеру 
	public string nickname = "";
	private Vector3 moveDirection;	// Вектор руху
	
	private float speed = 6.0f;		// швидкіст для внутрішніх розрахунків 
	public float speedStep = 6.0f;	// швидкіст хотьди
	public float speedShift = 9.0f;	// швидкіст бігу
	public float gravity = 20.0f;	// швидкіст падіння
	public float speedRotate = 4;	// швидкіст повороту
	public float jumpSpeed = 8;		// висота стрибка
	
	// Анімації та їх швидкості
	public AnimationClip a_Idle;
	public float a_IdleSpeed = 1;
	
	public AnimationClip a_Walk;
	public float a_WalkSpeed = 1;
	
	public AnimationClip a_Run;
	public float a_RunSpeed = 1;
	
	public AnimationClip a_Jump;
	public float a_JumpSpeed = 1;

	// Назва анімації що буде відтворюватися 
	private string s_anim;
	
	private CharacterController controller;	// Силка на контроллер

	// Змінні для інтерполяції
	private float lastSynchronizationTime = 0f;
	private float syncDelay = 0f;
	private float syncTime = 0f;
	private Vector3 syncStartPosition = Vector3.zero;
	private Vector3 syncEndPosition = Vector3.zero;

	//Змінні для сериалізації (синхронізації)
	private Quaternion rotStart;	// кут повороту
	private Quaternion rotEnd;
	private int numCurAnim;	// номер анімації для сереалізації 0 - стан спокою, 1 - хотьби 2 - бігу, 3 - прижка 
		

	void Awake ()
	{

		cam = transform.GetComponentInChildren<Camera> ().GetComponent<Camera> ();

		controller = GetComponent<CharacterController> ();
			
		GetComponent<Animation> () [a_Idle.name].speed = a_IdleSpeed;
		GetComponent<Animation> () [a_Walk.name].speed = a_WalkSpeed;
		GetComponent<Animation> () [a_Run.name].speed = a_RunSpeed;
		GetComponent<Animation> () [a_Jump.name].speed = a_JumpSpeed;
			
		GetComponent<Animation> () [a_Idle.name].wrapMode = WrapMode.Loop;
		GetComponent<Animation> () [a_Walk.name].wrapMode = WrapMode.Loop;
		GetComponent<Animation> () [a_Run.name].wrapMode = WrapMode.Loop;
		GetComponent<Animation> () [a_Jump.name].wrapMode = WrapMode.ClampForever;
			
		// Вказуємо стартову анімацію
		s_anim = a_Idle.name;
		numCurAnim = 0;
	}

	void OnGUI ()
	{
		Vector3 screenPos = Camera.main.WorldToScreenPoint (transform.position);
		GUI.Label (new Rect (screenPos.x - 15, screenPos.y - 15, 120, 30), nickname);
	}

	void Update ()
	{
		// Перевіряємо чи персонаж наш
		if (GetComponent<NetworkView> ().isMine) {
			// Якщо так то можна кереувати ним
			if (Input.GetMouseButtonDown (0)) {
				GameObject obj = (GameObject)Network.Instantiate (bal, transform.position + transform.TransformDirection (0, 0, 0.6f), transform.rotation, 1);
				obj.GetComponent<Rigidbody> ().velocity = transform.TransformDirection (0, 0, 20);
			}
						
			GetComponent<Animation> ().CrossFade (s_anim);
		
			if (controller.isGrounded) {
				moveDirection = new Vector3 (0, 0, Input.GetAxis ("Vertical"));
				moveDirection = transform.TransformDirection (moveDirection);
				moveDirection *= speed;
				
				if (Input.GetKey (KeyCode.LeftShift))
					speed = speedShift;
				else
					speed = speedStep;
				
				// Анимация ходьби
				if (Input.GetAxis ("Vertical") > 0) {
					if (speed == speedShift) {
						s_anim = a_Run.name;
						GetComponent<Animation> () [a_Run.name].speed = a_RunSpeed;
						numCurAnim = 2;
					} else {
						s_anim = a_Walk.name;
						GetComponent<Animation> () [a_Walk.name].speed = a_WalkSpeed;
						numCurAnim = 1;
					}
				} else 
				if (Input.GetAxis ("Vertical") < 0) {
					if (speed == speedShift) {
						s_anim = a_Run.name;
						GetComponent<Animation> () [a_Run.name].speed = a_RunSpeed * -1;
						numCurAnim = 2;
					} else {
						s_anim = a_Walk.name;
						GetComponent<Animation> () [a_Walk.name].speed = a_WalkSpeed * -1;
						numCurAnim = 1;
					}
				} else
				if (Input.GetAxis ("Vertical") == 0) {
					s_anim = a_Idle.name;
					numCurAnim = 0;
				}
				
				if (Input.GetKeyDown (KeyCode.Space)) {
					moveDirection.y = jumpSpeed;
					s_anim = a_Jump.name;
					numCurAnim = 3;
				}
			}

			// Обчислення плавного стрибка
			moveDirection.y -= gravity * Time.deltaTime;
			// Обчислення плавного переміщення
			controller.Move (moveDirection * Time.deltaTime);
			// Обчислення плавного повороту
			transform.Rotate (Vector3.down * speedRotate * Input.GetAxis ("Horizontal") * -1, Space.World);
		} else {
			// В протилежному випадку вимикаємо камеру та аудіо слухача
			// оскільки даний персонаж не мій
			if (cam.enabled) { 
				cam.enabled = false; 
				cam.gameObject.GetComponent<AudioListener> ().enabled = false;
			}
			// Виконуємо відправку даних
			SyncedMovement ();
		}
	}
	
	// Викликається в певні моменти часу та відповідає за 
	// сереалізацію змінних
	void OnSerializeNetworkView (BitStream stream, NetworkMessageInfo info)
	{
		Vector3 syncPosition = Vector3.zero;
		// Якщо персонаж наш то відправляємо дані на сервер
				
		if (stream.isWriting) {
			rotEnd = transform.rotation;
			syncPosition = transform.position;
			
			stream.Serialize (ref syncPosition);
			stream.Serialize (ref rotEnd);
			stream.Serialize (ref numCurAnim);
		} 
		// В протилежному випадку, якщо персонаш не наш, то 
		// читаємо координати з сервера 
		else {
			stream.Serialize (ref syncPosition);
			stream.Serialize (ref rotEnd);
			stream.Serialize (ref numCurAnim);

			// Визначаємо яку анімацію потрібно відтворити
			PlayNameAnim ();
			// Відтворюємо потрібну анімацію
			GetComponent<Animation> ().CrossFade (s_anim);
				
 
			// Обчислення інтерполяції			
			syncTime = 0f;
			// Час оновлення екрана
			syncDelay = Time.time - lastSynchronizationTime;
			lastSynchronizationTime = Time.time;
 
			syncStartPosition = transform.position;
			syncEndPosition = syncPosition;
			rotStart = transform.rotation;
		}
	}
	
	// Інтерполяція
	private void SyncedMovement ()
	{
		syncTime += Time.deltaTime;

		transform.position = Vector3.Lerp (syncStartPosition, syncEndPosition, syncTime / syncDelay);
		transform.rotation = Quaternion.Lerp (rotStart, rotEnd, syncTime / syncDelay);
		
	}
	
	// Визначає якому числу яка відповідає анімація 
	public void PlayNameAnim ()
	{
		switch (numCurAnim) {
		case 0:
			s_anim = a_Idle.name;
			break;
			
		case 1:
			s_anim = a_Walk.name;
			break;
			
		case 2:
			s_anim = a_Run.name;
			break;
			
		case 3:
			s_anim = a_Jump.name;
			GetComponent<Animation> () [a_Jump.name].wrapMode = WrapMode.ClampForever;//**
			break;
		}
	}
}
