using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	public float initialHealth = 100f;
	public float Health = 100f;

	void Start() {

	}
	
	void Update() {

	}

	void OnTriggerStay2D(Collider2D collision) {
		if(string.Compare(collision.gameObject.name, "Character") == 0) {
			Health -= Time.deltaTime * GameObject.Find("Character").GetComponent<Character>().Power;
			if(Health > 0) {
				float color = Health / initialHealth;
				GetComponent<SpriteRenderer>().color = new Color(1f, color, color);
			} else {
				transform.localScale = new Vector3();
			}
		}
	}
}
