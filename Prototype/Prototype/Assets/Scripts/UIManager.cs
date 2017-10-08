using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public Slider healthBar;
	public Text HPText;
	public PlayerHealthSystem playerHealth;
	public PlayerStats playerStats;

	public Slider healthBarEnemy;
	public Text HPTextEnemy;
	public MonsterHealth EnemyHealth;
	public GameObject enemyBar;

	public Slider playerExp;
	public Text playerExpText;
	public GameObject expBar;

	public GameObject combos;
	public ComboCounter comboC;

	// Use this for initialization
	void Start () {
		enemyBar.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		healthBar.maxValue = playerStats.maxHealth;
		healthBar.value = playerHealth.playerCurrentHealth;
		HPText.text = "" + playerHealth.playerCurrentHealth + "/" + playerStats.maxHealth;

		healthBarEnemy.maxValue = EnemyHealth.monsterMaxHealth;
		healthBarEnemy.value = EnemyHealth.monsterHealth;
		HPTextEnemy.text = "" + EnemyHealth.monsterHealth + "/" + EnemyHealth.monsterMaxHealth;

		playerExp.maxValue = playerStats.expNeedToLvl;
		playerExp.value = playerStats.currentExp;
		playerExpText.text = "" + playerStats.currentExp + "/" + playerStats.expNeedToLvl;

		if (EnemyHealth.monsterHealth < EnemyHealth.monsterMaxHealth){
			enemyBar.SetActive(true);
		}

		if (EnemyHealth.monsterHealth <= 0){
			enemyBar.SetActive(false);
		}

		if (comboC.comboCount == 1) {
			combos.SetActive (false);
		} else if (comboC.comboCount > 1){
			combos.SetActive(true);
		}
	}
}
