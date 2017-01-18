using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Ending : MonoBehaviour {
	int Step = 0;

	void Start() {
		InvokeRepeating("Next", 5f, 5f);
	}

	void Update() {

	}

	void Next() {
		switch(++Step) {
			case 1:
				GameObject.Find("Ending1").transform.localScale = new Vector3();
				break;
			case 2:
				GameObject.Find("Ending2").transform.localScale = new Vector3();
				break;
			case 3:
				GameObject.Find("Ending3").transform.localScale = new Vector3();
				break;
			default:
				SceneManager.LoadScene("Scenes/Main");
				break;
		}
	}
}
