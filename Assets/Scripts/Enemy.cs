using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	void Start() {
        Create();
	}
	
	void Update() {

	}

    void Create() {
        if(transform.localScale != new Vector3()) {

        } else if(Random.Range(0, GameObject.Find("EventSystem").GetComponent<Vessel>().enemyAppearProbability) == 0) {
            Debug.Log("Enemy Created");
            transform.localScale = new Vector3(.25f, .25f, 1f);
        } else {
            Invoke("Create", 5f);
        }
    }
}
