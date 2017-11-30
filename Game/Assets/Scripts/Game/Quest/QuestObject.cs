using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestObject : MonoBehaviour {

	public int questNumber;

	public QuestManager questManager;

	public string questName;
	public string questDescription;

	public bool isEnemyQuest;
	public string targetEnemy;
	public int enemiesToKill;
	private int enemyKillCount;

	public Text questNameText;
	public Text questDescriptionText;

	public int questEXP;

	public PlayerStats playerStats;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		questNameText.text = questName;
		questDescriptionText.text = questDescription;

		if (isEnemyQuest && questManager.questActive == true) {
			if (questManager.enemyKilled == targetEnemy) {
				questManager.enemyKilled = null;
				enemyKillCount++;
			}
			if (enemyKillCount >= enemiesToKill) {
				playerStats.currentExp = playerStats.currentExp + questEXP;
				questManager.EndQuest (questNumber);
			}
			questDescription = ("Kill " + enemiesToKill + " " + targetEnemy + "! (" + enemyKillCount + "/" + enemiesToKill + ")");
		}
	}
}
