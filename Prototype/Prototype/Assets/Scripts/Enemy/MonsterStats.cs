using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStats : MonoBehaviour {

	public string monsterName;
	public int monsterMaxHealth;
	public int monsterHealth;
	public PlayerStats playerstats;
	public int expToGive;

	// Use this for initialization
	void Start () {
		monsterHealth = monsterMaxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if (monsterHealth <= 0) {
			gameObject.SetActive (false);
			playerstats.currentExp = playerstats.currentExp + expToGive;
			playerstats.totalExp = playerstats.totalExp + expToGive;
			Destroy (gameObject);
		}
	}

	public void HurtMonster(int damageToGive){
		monsterHealth -= damageToGive; 
	}
}
