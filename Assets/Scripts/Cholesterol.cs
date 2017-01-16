using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cholesterol : MonoBehaviour {
	void Start() {
		
	}
	
	void Update() {
        if(transform.localScale != new Vector3()) {
            float deltaSize = Mathf.Lerp(transform.localScale.x, 5f, Time.deltaTime / GameObject.Find("EventSystem").GetComponent<Vessel>().cholesterolScaleDelta);
            transform.localScale = new Vector3(deltaSize, deltaSize, 1f);
        }
    }
}
