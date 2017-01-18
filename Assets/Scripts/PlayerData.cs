using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class PlayerData {
	/* PLAYER */
	[Serializable]
	public class PLAYER {
		public int Level = 0;
		public float[] Position = new float[3];

		public string Location = string.Empty;
		public string CreatedTime = string.Empty;
		public float PlayTime = 0f;
	}
	public static PLAYER Player_Default = new PLAYER();
	public static PLAYER Player = new PLAYER();

	/* OPTION */
	[Serializable]
	public class OPTION {
		public float volumeEffects = .5f;
		public float volumeBGM = .5f;
	}
	public static OPTION Option = new OPTION();

	/* VESSEL */
	[Serializable]
	public class ENEMY {
		public float initialHealth = 100f;
		public float Health = 0f;
		public float[] Position = new float[3];
		public float[] Scale = new float[3];
	}

	[Serializable]
	public class VESSEL {
		public ENEMY[] Enemy = new ENEMY[37];
		public bool Stomach = false;
		public bool Colon = false;
		public bool Liver = false;
	}
    public static VESSEL Vessel = new VESSEL();

	public static bool flagLoadPlayerData = false;

	public static void DeletePlayerData() {
		PlayerPrefs.DeleteKey("PlayerData");
	}

	public static void SavePlayerData() {
		BinaryFormatter bf = new BinaryFormatter();
		MemoryStream ms = new MemoryStream();

		bf.Serialize(ms, Player);
		PlayerPrefs.SetString("PlayerData", Convert.ToBase64String(ms.GetBuffer()));

		bf = new BinaryFormatter();
		ms = new MemoryStream();
		bf.Serialize(ms, Vessel);
		PlayerPrefs.SetString("VesselData", Convert.ToBase64String(ms.GetBuffer()));

		flagLoadPlayerData = true;
	}

	public static object ReadPlayerData(string type) {
		string data;

		try {
			// 문자열 데이터 불러옴
			data = PlayerPrefs.GetString(type);

			// 빈 데이터가 아닌 경우
			if(!string.IsNullOrEmpty(data)) {
				BinaryFormatter bf = new BinaryFormatter();
				MemoryStream ms = new MemoryStream();

				// 문자열 데이터를 Byte 배열 형태로 변환
				ms = new MemoryStream(Convert.FromBase64String(data));
				return bf.Deserialize(ms);
			}
		} catch { }

		return null;
	}

	public static void LoadPlayerData() {
		// 불러오기에 실패한 경우
		if((Player = (PLAYER)ReadPlayerData("PlayerData")) == null) {
			// 데이터를 기본 값으로 설정
			Player = Player_Default;
		} else {
			// 데이터 적용
			GameObject.Find("Character").transform.position = new Vector3(Player.Position[0], Player.Position[1], Player.Position[2]);
		}

		if((Vessel = (VESSEL)ReadPlayerData("VesselData")) == null) {
			Vessel = null;
		} else {
			for(int i = 1; i < Vessel.Enemy.Length; i++) {
				Transform enemy = GameObject.Find(i.ToString()).transform;
				enemy.GetComponent<Enemy>().initialHealth = Vessel.Enemy[i].initialHealth;
				enemy.GetComponent<Enemy>().Health = Vessel.Enemy[i].Health;
				enemy.position = new Vector3(Vessel.Enemy[i].Position[0], Vessel.Enemy[i].Position[1], Vessel.Enemy[i].Position[2]);
				enemy.localScale = new Vector3(Vessel.Enemy[i].Scale[0], Vessel.Enemy[i].Scale[1], Vessel.Enemy[i].Scale[2]);
			}
			GameObject.Find("Stomach").GetComponent<Entrance>().Cared = Vessel.Stomach;
			GameObject.Find("Colon").GetComponent<Entrance>().Cared = Vessel.Colon;
			GameObject.Find("Liver").GetComponent<Entrance>().Cared = Vessel.Liver;
		}
	}

	public static void SaveOptionData() {
		BinaryFormatter bf = new BinaryFormatter();
		MemoryStream ms = new MemoryStream();

		// 데이터를 Byte 배열 형태로 변환
		bf.Serialize(ms, Option);
		// 문자열로 변환하여 저장
		PlayerPrefs.SetString("OptionData", Convert.ToBase64String(ms.GetBuffer()));
	}

	public static void LoadOptionData() {
		string data;

		try {
			// 문자열 데이터 불러옴
			data = PlayerPrefs.GetString("OptionData");

			// 빈 데이터가 아닌 경우
			if(!string.IsNullOrEmpty(data)) {
				BinaryFormatter bf = new BinaryFormatter();
				MemoryStream ms = new MemoryStream();

				// 문자열 데이터를 Byte 배열 형태로 변환
				ms = new MemoryStream(Convert.FromBase64String(data));
				Option = (OPTION)bf.Deserialize(ms);
			}
		} catch { }
	}
}
