using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drink : MonoBehaviour {
	public bool Destroying = false;

	void Start() {

	}

	void Update() {
		float alpha;

		transform.position = new Vector3(transform.position.x, transform.position.y - Time.deltaTime, transform.position.z);
		alpha = GetComponent<SpriteRenderer>().color.a - Time.deltaTime * 2f;

		if(Destroying) {
			if(alpha < 0f)
				DestroyObject(gameObject);
			else
				GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, alpha);
		}

		if(transform.position.y < GameObject.Find("Character").transform.position.y)
			Destroying = true;
	}

	void OnTriggerStay2D(Collider2D collision) {
		if(string.Compare(collision.name, "Character") == 0) {
			Character_Liver chr = GameObject.Find("Character").GetComponent<Character_Liver>();
			if(string.Compare(name, "Soju") == 0 && chr.Health > 0)
				chr.Health--;
			else if(string.Compare(name, "VDrink") == 0) {
				chr.Health++;
				chr.getAnim = 1f;
			}
			DestroyObject(gameObject);
		}
	}
}
