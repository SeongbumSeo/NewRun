using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vessel : MonoBehaviour {
	public float cholesterolScaleDelta = 1000f;
	public int enemyAppearProbability = 20;
	public float cholesterolInitialHealth = 10f;
	public float nematodeInitialHealth = 200f;
	public bool inMiniGame = false;

	void Start() {

	}

	void Update() {

	}

	public void Pause() {
		GameObject.Find("EventSystem").GetComponent<Behaviour>().enabled = false;
		GameObject.Find("Main Camera").GetComponent<AudioListener>().enabled = false;
		GameObject.Find("Character").GetComponent<Character>().enabled = false;
	}

	public void Continue() {
		GameObject.Find("EventSystem").GetComponent<Behaviour>().enabled = true;
		GameObject.Find("Main Camera").GetComponent<AudioListener>().enabled = true;
		GameObject.Find("Character").GetComponent<Character>().enabled = true;
	}
}
