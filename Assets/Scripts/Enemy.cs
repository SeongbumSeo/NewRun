using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	public float initialHealth = 100f;
	public float Health = 100f;

	void Start() {
	}
	
	void Update() {
		int id = System.Int32.Parse(name);
		PlayerData.Vessel.Enemy[id].initialHealth = initialHealth;
		PlayerData.Vessel.Enemy[id].Health = Health;
		PlayerData.Vessel.Enemy[id].Position = new float[3] {
			transform.position.x,
			transform.position.y,
			transform.position.z
		};
		PlayerData.Vessel.Enemy[id].Scale = new float[3] {
			transform.localScale.x,
			transform.localScale.y,
			transform.localScale.z
		};

		if(Health > 0f) {
			float color = Health / initialHealth;
			GetComponent<SpriteRenderer>().color = new Color(1f, color, color);
		}
	}

	void OnTriggerStay2D(Collider2D collision) {
		if(string.Compare(collision.gameObject.name, "Character") == 0) {
			Health -= Time.deltaTime * GameObject.Find("Character").GetComponent<Character>().Power;
			if(Health <= 0f)
				transform.localScale = new Vector3();
		}
	}
}
