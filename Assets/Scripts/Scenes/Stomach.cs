using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Stomach : MonoBehaviour {
	public int innerFoods = 0;

	void Start() {
		InvokeRepeating("CreateFood", 1f, 1.5f);
	}
	
	void Update() {
		/* 가장 아래에 있는 음식에 Rigidbody 컴포넌트 추가 */
		GameObject obj = null;
		float position = GameObject.Find("BeltStart").transform.position.y + .1f;
		foreach(GameObject objs in GameObject.FindGameObjectsWithTag("Food")) {
			if(objs.transform.position.y < position && !objs.GetComponent<Food>().Destroying) {
				obj = objs;
				position = objs.transform.position.y;
			}
		}
		if(obj != null && obj.GetComponents<Rigidbody2D>().Length == 0)
			obj.gameObject.AddComponent<Rigidbody2D>();

		/* 받은 음식 수 출력 */
		GameObject.Find("NumFoods").GetComponent<TextMesh>().text = innerFoods.ToString();

		/* 받은 음식 수가 30개 이상일 경우 종료 */
		if(innerFoods >= 30) {
			SceneManager.LoadScene("Scenes/Vessel");
		}
	}

	void CreateFood() {
		GameObject food = GameObject.Instantiate(GameObject.Find("BeltStart"));
		string type;

		// 태그 설정
		food.tag = "Food";
		// 이미지 랜덤 적용 (햄버거 or 샐러드)
		switch(Random.Range(0, 3)) {
			case 0:		type = "Hamburger";	break;
			case 1:		type = "Chicken";	break;
			default:	type = "Salad";		break;
		}
		food.GetComponent<SpriteRenderer>().sprite = GameObject.Find(type).GetComponent<SpriteRenderer>().sprite;
		// 이름 설정
		food.name = type;
		// Z값 설정
		food.transform.position = new Vector3(food.transform.position.x, food.transform.position.y, -1);
		// 스케일 설정
		food.transform.localScale = new Vector3(.1f, .1f, 1f);
		// Food 컴포넌트 추가
		food.AddComponent<Food>();
		// Collider 컴포넌트 추가
		PolygonCollider2D col = food.AddComponent<PolygonCollider2D>();
		col.points = GameObject.Find(type).GetComponent<PolygonCollider2D>().points;
		col.isTrigger = true;
	}
}
