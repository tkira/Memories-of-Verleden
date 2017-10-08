using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealth : MonoBehaviour {

	public int monsterMaxHealth;
	public int monsterHealth;
	public PlayerStats playerstats;

	// Use this for initialization
	void Start () {
		monsterHealth = monsterMaxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if (monsterHealth <= 0) {
			gameObject.SetActive (false);
			playerstats.currentExp++;
			Destroy (gameObject);
		}
	}

	public void HurtMonster(int damageToGive){
		monsterHealth -= damageToGive; 
	}
}
