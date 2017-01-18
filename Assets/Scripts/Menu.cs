using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour {
	public bool Escaping = false;

	void Start() {
		
	}
	
	void Update() {
		SpriteRenderer fader = GameObject.Find("MenuFader").GetComponent<SpriteRenderer>();
		if(Escaping) {
			if(Input.GetKeyDown(KeyCode.Escape)) {
				Resume();
			} else {
				float alpha = Mathf.Lerp(fader.color.a, .7f, Time.deltaTime);
				fader.color = new Color(0f, 0f, 0f, alpha);
			}
		} else if(Input.GetKeyDown(KeyCode.Escape)) {
			Escaping = true;
			GameObject.Find("Menu").transform.localScale = new Vector3(1f, 1f, 1f);
		}
	}

	public void Resume() {
		SpriteRenderer fader = GameObject.Find("MenuFader").GetComponent<SpriteRenderer>();
		Escaping = false;
		fader.color = new Color(0f, 0f, 0f, 0f);
		GameObject.Find("Menu").transform.localScale = new Vector3(0f, 0f, 0f);
	}

	public void Save() {
		PlayerData.SavePlayerData();
	}

	public void Quit() {
		SceneManager.LoadScene("Scenes/Main");
	}
}
