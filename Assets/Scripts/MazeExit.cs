using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MazeExit : MonoBehaviour {
	void Start() {
		
	}
	
	void Update() {
		
	}

	void OnTriggerStay2D(Collider2D collision) {
		if(string.Compare(collision.name, "Character") == 0) {
			SceneManager.LoadScene("Scenes/Vessel");
		}
	}
}
