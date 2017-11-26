﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using LitJson;

public class SaveManager : MonoBehaviour {

	string ss = "Test2";

	public PlayerData playerData;
	public PlayerStats playerStats;
	public StoryManager storyManager;

	public FragmentMemoryManager memoryManager;

	JsonData jsonData;

	void OnEnable(){
		playerData = new PlayerData ();
	}

	public void SaveData()
	{	
		SavePlayer ();

		jsonData = JsonMapper.ToJson (playerData);
		File.WriteAllText (Application.dataPath + "/save.json", jsonData.ToString ());
        Debug.Log(jsonData);
	}

	public void SaveDataDB()
	{	
		WWWForm form = new WWWForm ();
		form.AddField ("a", ss);
		form.AddField ("b", 2);
		form.AddField ("c", 4);
		form.AddField ("d", 6);

		WWW www = new WWW ("localhost/Memories_Of_Verleden/PlayerSaveInsert.php", form);
		Debug.Log("SaveDB");
	}

	public IEnumerator LoadDataDB()
	{	
		WWW playerDataDB = new WWW ("http://localhost/Memories_Of_Verleden/PlayerSave.php");
		yield return playerDataDB;
		string playerDataString = playerDataDB.text;

	}

	public void LoadData()
	{
		string loadData = File.ReadAllText(Application.dataPath + "/save.json");

		playerData = JsonUtility.FromJson<PlayerData> (loadData);

		LoadPlayer ();
	}

	public void SavePlayer(){
		playerData.currentLvl = playerStats.currentLvl;
		playerData.currentExp = playerStats.currentExp;
		playerData.expNeedToLvl = playerStats.expNeedToLvl;
		playerData.totalExp = playerStats.totalExp;
		playerData.statPoints = playerStats.statPoints;
		playerData.Strength = playerStats.Strength;
		playerData.Dexterity = playerStats.Dexterity;
		playerData.wisdom = playerStats.wisdom;
		playerData.Intelligence = playerStats.Intelligence;
		playerData.Defence = playerStats.Defence;
		playerData.Vitality = playerStats.Vitality;
		playerData.totalDamage = playerStats.totalDamage;
		playerData.totalMagicDam = playerStats.totalMagicDam;
		playerData.crit = playerStats.crit;
		playerData.magicCrit = playerStats.magicCrit;
		playerData.armor = playerStats.armor;
		playerData.dodge = playerStats.dodge;
		playerData.lightDefence = playerStats.lightDefence;
		playerData.darkDefence = playerStats.darkDefence;
		playerData.maxPowerBar = playerStats.maxPowerBar;
		playerData.powerBar = playerStats.powerBar;
		playerData.maxHealth = playerStats.maxHealth;
		playerData.playerCurrentHealth = playerStats.playerCurrentHealth;
		playerData.storiesCollected = memoryManager.storiesCollected;
		playerData.arcCompleted = storyManager.arcCompleted;
		playerData.memoryCount = playerStats.memoryCount;
	}

	public void LoadPlayer(){
		playerStats.currentLvl = playerData.currentLvl;
		playerStats.currentExp = playerData.currentExp;
		playerStats.expNeedToLvl = playerData.expNeedToLvl;
		playerStats.totalExp = playerData.totalExp;
		playerStats.statPoints = playerData.statPoints;
		playerStats.Strength = playerData.Strength;
		playerStats.Dexterity = playerData.Dexterity;
		playerStats.wisdom = playerData.wisdom;
		playerStats.Intelligence = playerData.Intelligence;
		playerStats.Defence = playerData.Defence;
		playerStats.Vitality = playerData.Vitality;
		playerStats.totalDamage = playerData.totalDamage;
		playerStats.totalMagicDam = playerData.totalMagicDam;
		playerStats.crit = playerData.crit;
		playerStats.magicCrit = playerData.magicCrit;
		playerStats.armor = playerData.armor;
		playerStats.dodge = playerData.dodge;
		playerStats.lightDefence = playerData.lightDefence;
		playerStats.darkDefence = playerData.darkDefence;
		playerStats.maxPowerBar = playerData.maxPowerBar;
		playerStats.powerBar = playerData.powerBar;
		playerStats.maxHealth = playerData.maxHealth;
		playerStats.playerCurrentHealth = playerData.playerCurrentHealth;
		memoryManager.storiesCollected = playerData.storiesCollected;
		storyManager.arcCompleted = playerData.arcCompleted;
		playerStats.memoryCount = playerData.memoryCount;
	}
}