using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Vessel : MonoBehaviour {
	public float cholesterolScaleDelta = 1000f;
	public int enemyAppearProbability = 20;
	public float cholesterolInitialHealth = 10f;
	public float nematodeInitialHealth = 200f;
	public bool Paused = false;

	void Start() {

	}

	void Update() {
		if(Paused && string.Compare(SceneManager.GetActiveScene().name, "Vessel") == 0)
			Continue();
	}

	public void Pause() {
		Paused = true;
		GameObject.Find("EventSystem").GetComponent<Behaviour>().enabled = false;
		GameObject.Find("Main Camera").GetComponent<AudioListener>().enabled = false;
		GameObject.Find("Character").GetComponent<Character>().enabled = false;
	}

	public void Continue() {
		Paused = false;
		GameObject.Find("EventSystem").GetComponent<Behaviour>().enabled = true;
		GameObject.Find("Main Camera").GetComponent<AudioListener>().enabled = true;
		GameObject.Find("Character").GetComponent<Character>().enabled = true;
	}
}
