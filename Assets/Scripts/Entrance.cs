using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Entrance : MonoBehaviour {
	public bool Cared = false;

	bool Collided = false;
	public bool ColorMode = false;

	void Start() {
		
	}
	
	void Update() {
		Vessel scene = GameObject.Find("EventSystem").GetComponent<Vessel>();
		SpriteRenderer sprite = GetComponent<SpriteRenderer>();

		if(Collided && !scene.Paused) {
			SpriteRenderer blackScreen = GameObject.Find("BlackScreen").GetComponent<SpriteRenderer>();
			float alpha = Mathf.Lerp(blackScreen.color.a, 1.1f, Time.deltaTime);
			if(alpha > 1f) {
				Collided = false;
				Cared = true;

				switch(name) {
					case "Stomach":
						PlayerData.Vessel.Stomach = true;
						break;
					case "Colon":
						PlayerData.Vessel.Colon = true;
						break;
					case "Liver":
						PlayerData.Vessel.Liver = true;
						break;
				}

				PlayerData.SavePlayerData();
				SceneManager.LoadScene("Scenes/" + name);
				SceneManager.SetActiveScene(SceneManager.GetSceneByName(name));
			} else {
				blackScreen.color = new Color(1f, 1f, 1f, alpha);
			}
		}

		if(Cared) {
			sprite.color = new Color(1f, 1f, 1f);
		} else {
			float color = Mathf.Lerp(sprite.color.g, ColorMode ? 1.1f : .7f, Time.deltaTime);

			if(color <= .8f && !ColorMode)
				ColorMode = true;
			else if(color >= 1f && ColorMode)
				ColorMode = false;

			sprite.color = new Color(1f, color, color);
		}
	}

	void OnTriggerStay2D(Collider2D collision) {
		if(string.Compare(collision.name, "Character") == 0 && !GameObject.Find("EventSystem").GetComponent<Vessel>().Paused)
			Collided = true;
	}
}
