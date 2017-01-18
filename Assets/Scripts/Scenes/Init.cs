using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Init : MonoBehaviour {
	int Step = 0;

	void Start() {
		InvokeRepeating("Next", 5f, 5f);
	}
	
	void Update() {
		
	}

	void Next() {
		switch(++Step) {
			case 1:
				GameObject.Find("Init1").transform.localScale = new Vector3();
				break;
			case 2:
				GameObject.Find("Init2").transform.localScale = new Vector3();
				break;
			default:
				SceneManager.LoadScene("Scenes/Vessel");
				break;
		}
	}
}
