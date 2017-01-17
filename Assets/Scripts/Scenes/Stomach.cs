using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stomach : MonoBehaviour {
	void Start() {
		InvokeRepeating("CreateFood", 1f, 1.5f);
	}
	
	void Update() {
		
	}

	void CreateFood() {
		GameObject food = GameObject.Instantiate(GameObject.Find("BeltStart"));
		string type;

		// 이미지 랜덤 적용 (햄버거 or 샐러드)
		switch(Random.Range(0, 3)) {
			case 0:		type = "Hamburger";	break;
			case 1:		type = "Chicken";	break;
			default:	type = "Salad";		break;
		}
		food.GetComponent<SpriteRenderer>().sprite = GameObject.Find(type).GetComponent<SpriteRenderer>().sprite;
		// Z값 설정
		food.transform.position = new Vector3(food.transform.position.x, food.transform.position.y, -11);
		// Food 컴포넌트 추가
		food.AddComponent<Food>();
	}
}
