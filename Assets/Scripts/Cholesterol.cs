using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cholesterol : MonoBehaviour {
	Vector3 initialPosition;

	void Start() {
		// 초기 좌표 기억
		initialPosition = transform.position;
		// 생성
		Create();
    }
	
	void Update() {
        if(transform.localScale != new Vector3()) {
            float deltaSize = Mathf.Lerp(transform.localScale.x, 5f, Time.deltaTime / GameObject.Find("EventSystem").GetComponent<Vessel>().cholesterolScaleDelta);
            transform.localScale = new Vector3(deltaSize, deltaSize, 1f);
        }
    }

    void Create() {
        if(transform.localScale != new Vector3()) {

        } else if(Random.Range(0, GameObject.Find("EventSystem").GetComponent<Vessel>().enemyAppearProbability) == 0) {
			// 체력 설정
			GetComponent<Enemy>().Health = GameObject.Find("EventSystem").GetComponent<Vessel>().cholesterolInitialHealth;
			// 초기 좌표로 이동
			transform.position = initialPosition;
			// 생성
			transform.localScale = new Vector3(.25f, .25f, 1f);
        } else {
            Invoke("Create", 5f);
        }
    }
}
