using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour {
	public bool Destroying = false;

	string Direction = "Down";

	void Start() {

	}

	void Update() {
		/* 좌표 이동 및 투명도 조절 */
		float alpha;

		switch(Direction) {
			case "Left":
				transform.position = new Vector3(transform.position.x - Time.deltaTime, transform.position.y, transform.position.z);
				alpha = GetComponent<SpriteRenderer>().color.a - Time.deltaTime;
				break;
			case "Right":
				transform.position = new Vector3(transform.position.x + Time.deltaTime, transform.position.y, transform.position.z);
				alpha = GetComponent<SpriteRenderer>().color.a - Time.deltaTime;
				break;
			default:
				transform.position = new Vector3(transform.position.x, transform.position.y - Time.deltaTime, transform.position.z);
				alpha = GetComponent<SpriteRenderer>().color.a - Time.deltaTime * 2f;
				break;
		}
		
		if(Destroying) {
			if(alpha < 0f) {
				if(Direction == "Right") {
					Stomach stomach = GameObject.Find("EventSystem").GetComponent<Stomach>();
					if(string.Compare(name, "Salad") == 0)
						stomach.innerFoods++;
					else if(stomach.innerFoods > 0)
						stomach.innerFoods--;
				}
				DestroyObject(gameObject);
			} else {
				GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, alpha);
			}
		}

		/* 크기 확대 */
		float scale = transform.localScale.x + Time.deltaTime / 100f;
		transform.localScale = new Vector3(scale, scale, 1f);
	}

	void OnTriggerStay2D(Collider2D collision) {
		if(string.Compare(collision.name, "BeltEnd") == 0 && !Destroying) {
			if(Input.GetKey(KeyCode.LeftArrow)) {
				Direction = "Left";
				Destroying = true;
			} else if(Input.GetKey(KeyCode.RightArrow)) {
				Direction = "Right";
				Destroying = true;
			}
		}
	}

	void OnTriggerExit2D(Collider2D collision) {
		Destroying = true;
	}
}
