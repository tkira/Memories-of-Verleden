using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStats : MonoBehaviour {

	public string monsterName;
	public int monsterLvl;
	public int monsterMaxHealth;
	public int monsterHealth;
	public int monsterDamage;
	public PlayerStats playerstats;
	public int expToGive;

	public string enemyQuestName;
	private QuestManager questManager;

	// Use this for initialization
	void Start () {
		monsterHealth = monsterMaxHealth;
		questManager = FindObjectOfType<QuestManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (monsterHealth <= 0) {
			gameObject.SetActive (false);
			questManager.enemyKilled = enemyQuestName;
			playerstats.currentExp = playerstats.currentExp + expToGive;
			playerstats.totalExp = playerstats.totalExp + expToGive;

			DropHandler itemDrop = new DropHandler();
			Vector3 currentPosition = transform.position;
			itemDrop.calcDrop (currentPosition);

			Destroy (gameObject);


		}
	}

	public void HurtMonster(int damageToGive){
		monsterHealth -= damageToGive; 
	}
}
