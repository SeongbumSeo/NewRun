using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour {
	void Start() {
		
	}
	
	void Update() {
		/* 좌표 이동 */
		float endposition = GameObject.Find("BeltEnd").transform.position.y;
		float position = transform.position.y - Time.deltaTime;
		if(position > endposition) {
			transform.position = new Vector3(transform.position.x, position, transform.position.z);
		} else {
			DestroyObject(gameObject);
		}

		/* 크기 확대 */
		float scale = transform.localScale.x + Time.deltaTime / 100f;
		transform.localScale = new Vector3(scale, scale, 1f);
	}
}
