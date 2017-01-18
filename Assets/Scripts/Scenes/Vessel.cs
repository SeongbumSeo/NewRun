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
		for(int i = 0; i < 37; i++)
			PlayerData.Vessel.Enemy[i] = new PlayerData.ENEMY();

		if(PlayerData.flagLoadPlayerData) {
			PlayerData.LoadPlayerData();
			Vector3 pos = GameObject.Find("Character").transform.position;
			GameObject.Find("Character").transform.position = new Vector3(pos.x, pos.y + 7f, pos.z);
		}
	}

	void Update() {
		int enemies = 0;

		for(int i = 1; i < 37; i++)
			if(GameObject.Find(i.ToString()).transform.localScale != new Vector3())
				enemies++;

		if(enemies < 10 && PlayerData.Player.PlayTime >= 60f
			&& GameObject.Find("Stomach").GetComponent<Entrance>().Cared
			&& GameObject.Find("Colon").GetComponent<Entrance>().Cared
			&& GameObject.Find("Liver").GetComponent<Entrance>().Cared) {
			SceneManager.LoadScene("Scenes/Ending");
		}
		
		PlayerData.Player.PlayTime += Time.deltaTime;
	}
}
