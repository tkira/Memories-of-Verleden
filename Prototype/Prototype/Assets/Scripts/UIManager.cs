using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public Slider healthBar;
	public Text HPText;
	public PlayerHealthSystem playerHealth;

	public Slider healthBarEnemy;
	public Text HPTextEnemy;
	public MonsterHealth EnemyHealth;
	public GameObject enemyBar;

	public GameObject combos;
	public ComboCounter comboC;

	// Use this for initialization
	void Start () {
		enemyBar.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		healthBar.maxValue = playerHealth.playerMaxHealth;
		healthBar.value = playerHealth.playerCurrentHealth;
		HPText.text = "HP: " + playerHealth.playerCurrentHealth + "/" + playerHealth.playerMaxHealth;

		healthBarEnemy.maxValue = EnemyHealth.monsterMaxHealth;
		healthBarEnemy.value = EnemyHealth.monsterHealth;
		HPTextEnemy.text = "HP: " + EnemyHealth.monsterHealth + "/" + EnemyHealth.monsterMaxHealth;

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
