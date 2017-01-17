using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	public float Health = 100f;

	bool Damaging = false;

	void Start() {

	}
	
	void Update() {
		if(Damaging) {
			Health -= Time.deltaTime * GameObject.Find("Character").GetComponent<Character>().Power;
			if(Health < 0) {
				Damaging = false;
				transform.localScale = new Vector3();
			}
		}
	}

	void OnTriggerEnter2D(Collider2D collision) {
		Damaging = string.Compare(collision.gameObject.name, "Character") == 0;
	}

	void OnTriggerExit2D(Collider2D collision) {
		Damaging &= string.Compare(collision.gameObject.name, "Character") != 0;
	}
}
