using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	public float Health = 100f;

	void Start() {

	}
	
	void Update() {

	}

	void OnTriggerStay2D(Collider2D collision) {
		if(string.Compare(collision.gameObject.name, "Character") == 0) {
			Health -= Time.deltaTime * GameObject.Find("Character").GetComponent<Character>().Power;
			if(Health < 0)
				transform.localScale = new Vector3();
		}
	}
}
