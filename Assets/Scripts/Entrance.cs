using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Entrance : MonoBehaviour {
	bool Collided = false;

	void Start() {
		
	}
	
	void Update() {
		Vessel scene = GameObject.Find("EventSystem").GetComponent<Vessel>();
		if(Collided && !scene.Paused) {
			SpriteRenderer blackScreen = GameObject.Find("BlackScreen").GetComponent<SpriteRenderer>();
			float alpha = Mathf.Lerp(blackScreen.color.a, 1.1f, Time.deltaTime);
			if(alpha > 1f) {
				Collided = false;

				PlayerData.SavePlayerData();
				SceneManager.LoadScene("Scenes/" + name);
				SceneManager.SetActiveScene(SceneManager.GetSceneByName(name));
			} else {
				blackScreen.color = new Color(1f, 1f, 1f, alpha);
			}
		}
	}

	void OnTriggerStay2D(Collider2D collision) {
		if(string.Compare(collision.name, "Character") == 0 && !GameObject.Find("EventSystem").GetComponent<Vessel>().Paused)
			Collided = true;
	}
}
