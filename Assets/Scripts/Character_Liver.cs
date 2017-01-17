using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Character_Liver : MonoBehaviour {
	public float moveSpeed = 10f;
	public float moveSlip = 10f;
	public int Health = 0;
	public float getAnim = 0f;
	public Sprite getSprite;

	float characterSpeedX = 0f;
	Sprite originalSprite;

	void Start() {
		originalSprite = GetComponent<SpriteRenderer>().sprite;
		InvokeRepeating("CreateDrink", 1f, 1f);
	}

	void Update() {
		// 이동중 여부 체크 변수
		bool ismoving = false;

		/* 캐릭터 이동 */
		float deltaSpeed = Time.deltaTime * moveSpeed / moveSlip;
		
		// 좌향 이동
		if(Input.GetKey(KeyCode.LeftArrow)) {
			ismoving = true;
			characterSpeedX = Mathf.Lerp(characterSpeedX, -moveSpeed, deltaSpeed);
		}
		// 우향 이동
		if(Input.GetKey(KeyCode.RightArrow)) {
			ismoving = true;
			characterSpeedX = Mathf.Lerp(characterSpeedX, moveSpeed, deltaSpeed);
		}

		// 이동중인 경우
		if(ismoving) {
			// 정지 해제
			GetComponent<Rigidbody2D>().isKinematic = false;
		} else {
			// X감속
			characterSpeedX = Mathf.Lerp(characterSpeedX, 0f, deltaSpeed);
		}
		// 속도 처리
		GetComponent<Rigidbody2D>().velocity = new Vector3(characterSpeedX, 0f, 0f);

		if(getAnim > 0f) {
			getAnim -= Time.deltaTime;
			GetComponent<SpriteRenderer>().sprite = getSprite;
		} else {
			GetComponent<SpriteRenderer>().sprite = originalSprite;
		}

		Transform hText = GameObject.Find("HealthText").transform;
		hText.position = new Vector3(transform.position.x, transform.position.y, hText.position.z);
		hText.GetComponent<TextMesh>().text = Health.ToString();

		if(Health >= 30)
			SceneManager.LoadScene("Scenes/Vessel");
	}

	void CreateDrink() {
		float x = Random.Range(-9f, 9f);
		string type = Random.Range(0, 2) == 0 ? "SojuEx" : "VDrinkEx";
		Transform drink = GameObject.Instantiate(GameObject.Find(type)).transform;

		drink.name = type.Substring(0, type.Length - 2);
		drink.position = new Vector3(x, 5f, -1f);
		drink.gameObject.AddComponent<Drink>();
	}
}
